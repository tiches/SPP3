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
        public DateTime DateDateTime { get; set; }
        public string Description { get; set; }
    }
}
