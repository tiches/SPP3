using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppLibrary
{
    public class PlannedDate
    {
        public int DateID { get; set; }
        public int MatchID { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
        public int userIDone { get; set; }
        public int userIDtwo { get; set; }
    }
}
