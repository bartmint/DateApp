using DateApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateApp.Domain.Abstract
{
    public interface IMessageRepository
    {
        void AddMessage(Message message);
            void DeleteMessage(Message message);
        Task<Message> GetMessage(int id);
        IQueryable<Message> GetMessagesForUser(string container, string username);
        Task<IEnumerable<Message>> GetMessageThread(string currentUsername, string recipientUsername);
        Task<bool> SaveAllAsync();
    }
}
