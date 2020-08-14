using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenmoServer.Models
{
    public class Account
    {
        public Account()
        {

        }

        public Account(int accountID, int userID, decimal accountBalance, bool isLoggedInUser)
        {
            AccountID = accountID;
            UserID = userID;
            AccountBalance = accountBalance;
            IsLoggedInUser = isLoggedInUser;
        }

        public int AccountID { get; set; }
        public int UserID { get; set; }
        public decimal AccountBalance { get; set; }
        public bool IsLoggedInUser { get; set; }
    }
}
