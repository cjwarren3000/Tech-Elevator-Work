using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserDAO userDAO;
        private readonly IAccountDAO accountDAO;

        public AccountsController(IUserDAO _userDAO, IAccountDAO _AccountDAO)
        {
            userDAO = _userDAO;
            accountDAO = _AccountDAO;
        }

        [HttpGet("User")]
        public List<User> GetUsers()
        {
            List<User> ListOfUsers = userDAO.GetUsers();
            int userId = 0;
            foreach (var claim in base.User.Claims)
            {
                if (claim.Type == "sub")
                {
                    userId = int.Parse(claim.Value);
                }
            }
            ListOfUsers[ListOfUsers.FindIndex(u => u.UserId == userId)].Username += " (You)";
            return ListOfUsers;
        }

        [HttpGet("User/Account")]
        public Account GetUsersAccount()
        {
            int id = -1;

            foreach (var claim in base.User.Claims)
            {
                if (claim.Type == "sub")
                {
                    id = int.Parse(claim.Value);
                }
            }

            return accountDAO.GetUsersAccount(id);
        }

        [HttpGet]
        public List<Account> AccountInfo()
        {
            int id = 0;

            foreach (var claim in User.Claims)
            {
                if (claim.Type == "sub")
                {
                    id = int.Parse(claim.Value);
                }
            }
            
            return accountDAO.AccountInfo(id);
        }

        [HttpPut]
        public ActionResult<Account> UpdateAccountBalance(Account accountToUpdate)
        {
            Account updatedAccount = accountDAO.UpdateAccountBalance(accountToUpdate);
            if (updatedAccount == null)
            {
                return NotFound("Account does not exist.");
            }
            return Ok(updatedAccount);
        }
        
    }
}