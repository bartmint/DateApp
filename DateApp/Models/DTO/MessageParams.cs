using DateApp.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateApp.UI.Models.DTO
{
    public class MessageParams: PaginationParams
    {
        public string Username { get; set; }
        public string Container { get; set; } = "Unread";
    }
}
