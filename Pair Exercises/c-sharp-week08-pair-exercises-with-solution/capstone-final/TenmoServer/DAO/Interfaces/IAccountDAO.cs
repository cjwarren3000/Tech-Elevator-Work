using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface IAccountDAO
    {
        Account GetAccount(int user_id);
        bool Deposit(Transfer transfer);
        bool Withdrawal(Transfer transfer);
        Dictionary<int, int> AccountToUser();
        Dictionary<int, string> UserToName();
        Dictionary<int, string> TypeToName();
        Dictionary<int, string> StatusToName();
    }
}
