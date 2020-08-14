using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenmoServer.Models
{
    public class Log
    {
        public int TransferId { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public decimal Amount { get; set; }
    }
}
