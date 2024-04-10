using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppLibrary
{
    public class DateRequest
    {
        public int RequestID { get; set; }
        public int MatchID { get; set; }
        public int SenderUserID { get; set; }
        public int ReceiverUserID { get; set; }
        public string Status { get; set; }
    }
}
