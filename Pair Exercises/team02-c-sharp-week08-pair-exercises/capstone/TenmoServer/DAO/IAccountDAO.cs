﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface IAccountDAO
    {
       List<Account> AccountInfo(int loggedInUserId);
        Account GetUsersAccount(int loggedInUserId);
        Account UpdateAccountBalance(Account accountToUpdate);
    }
}
