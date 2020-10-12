using System;
using System.Collections.Generic;
using System.Text;

namespace DateApp.Domain.Models
{
    public class UserLike
    {
        public AppUser SourceUser { get; set; }
        public int SourceUserId { get; set; }
        

        public AppUser LikedUser { get; set; }
        public int LikedUserId { get; set; }
    }
}
