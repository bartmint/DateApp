using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateApp.UI.Helpers
{
    public class UserParams:PaginationParams
    {
        //filtrowanie
        public string CurrentUsername { get; set; }
        public string Gender { get; set; }
        public int MinAge { get; set; } = 18;
        public int MaxAge { get; set; } = 150;

        //sorting
        public string OrderBy { get; set; } = "lastActive";

    }
}
