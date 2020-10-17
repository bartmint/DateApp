using DateApp.Domain.Abstract;
using DateApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateApp.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _ctx;

        public MessageRepository(AppDbContext appDbContext)
        {
            _ctx = appDbContext;
        }

        public void AddGroup(Group group)
        {
            _ctx.Groups.Add(group);
        }

        public void AddMessage(Message message)
        {
            _ctx.Messages.Add(message);
        }

        public void DeleteMessage(Message message)
        {
            _ctx.Messages.Remove(message);
        }

        public async Task<Connection> GetConnection(string connectionId)
        {
            return await _ctx.Connection.FindAsync(connectionId);
        }

        public async Task<Message> GetMessage(int id)
        {
            return await _ctx.Messages
                .Include(u => u.Sender)
                .Include(p => p.Recipient)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async  Task<Group> GetMessageGroup(string groupName)
        {
            return await _ctx.Groups
                 .Include(x => x.Connections)
                 .FirstOrDefaultAsync(x => x.Name == groupName);
        }

        public IQueryable<Message> GetMessagesForUser(string container, string username)
        {
            var query = _ctx.Messages
                 .OrderByDescending(m => m.Messagesent)
                 .AsQueryable();

            query = container switch
            {
                "Inbox" => query.Where(u => u.Recipient.UserName == username && u.RecipientDeleted==false),
                "Outbox" => query.Where(u => u.Sender.UserName == username && u.SenderDeleted == false),
                _ => query.Where(u => u.Recipient.UserName == username && u.RecipientDeleted==false && u.DateRead == null)
            };
            return query;
        }

      

        public async Task<IEnumerable<Message>> GetMessageThread(string currentUsername, string recipientUsername)
        {
            var messages =await _ctx.Messages
                .Include(u => u.Sender).ThenInclude(p => p.Photos)
                .Include(u => u.Recipient).ThenInclude(p => p.Photos)
                .Where(m => m.Recipient.UserName == currentUsername && m.RecipientDeleted==false
                && m.Sender.UserName == recipientUsername
                || m.Recipient.UserName == recipientUsername
                && m.Sender.UserName == currentUsername && m.SenderDeleted==false)
                .OrderBy(m => m.Messagesent)
                .ToListAsync();

            var unreadMessages =  messages.Where(m => m.DateRead == null && m.Recipient.UserName == currentUsername);
            if (unreadMessages.Any())
            {
                foreach (var message in unreadMessages)
                {
                    message.DateRead = DateTime.Now;
                }
                await _ctx.SaveChangesAsync();
            }
            return messages;

        }

        public void RemoveConnection(Connection connection)
        {
            _ctx.Connection.Remove(connection);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}
