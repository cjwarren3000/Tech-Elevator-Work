using System;
using System.Collections.Generic;
using System.Text;

namespace TenmoClient.Data
{
    public class Transfer
    {
        public int transferId { get; set; }
        public int transferTypeId { get; set; }
        public string transferTypeDesc { get; set; }
        public int transferStatusId { get; set; }
        public string transferStausDesc { get; set; }
        public int accountFrom { get; set; }
        public string accountFromName { get; set; }
        public int accountTo { get; set; }
        public string accountToName { get; set; }
        public decimal amount { get; set; }
    }
}
