using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class MoneyController : ControllerBase
    {
        private readonly IAccountDAO accountDAO;
        private readonly IUserDAO userDAO;
        private readonly ITransferDAO transferDAO;

        public MoneyController(IAccountDAO accountDAO, IUserDAO userDAO, ITransferDAO transferDAO)
        {
            this.transferDAO = transferDAO;
            this.accountDAO = accountDAO;
            this.userDAO = userDAO;
        }

        [HttpGet("balance")]
        public ActionResult GetBalance()
        {
            Account account = accountDAO.GetAccount(GetUserId());
            decimal balance = account.Balance;
            return StatusCode(200, balance);
        }

        [HttpGet("users")]
        public List<User> GetUsers()
        {
            List<User> users = userDAO.GetUsers();
            return users;
        }

        [HttpGet("transfers")]
        public List<TransferRecord> GetTransfers()
        {
            List<TransferRecord> transfers = transferDAO.GetTransfers(GetUserId());
            return transfers;
        }

        [HttpPost("transferfrom")]
        public bool TransferFrom(Transfer transfer)
        {
            //does ID match request?
            int destinationUserId = GetUserId();
            if (destinationUserId != transfer.ToUser)
            {
                return false;
            }

            //requesting account is the destination account
            Account destinationAccount = accountDAO.GetAccount(destinationUserId);

            //get source account for logging
            Account sourceAccount = accountDAO.GetAccount(transfer.FromUser);

            //update transfer info
            Log log = new Log
            {
                ToId = destinationAccount.AccountId,
                FromId = sourceAccount.AccountId,
                Amount = transfer.Amount,
                Type = TransferType.REQUEST,
                Status = StatusType.PENDING
            };

            if (!transferDAO.AddTransfer(log))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        [HttpPost("transferto")]
        public bool TransferTo(Transfer transfer)
        {
            //does ID match request?
            int loggedinUserId = GetUserId();
            if (loggedinUserId != transfer.FromUser)
            {
                return false;
            }

            //is there enough money?
            Account sourceAccount = accountDAO.GetAccount(loggedinUserId);
            if (sourceAccount.Balance < transfer.Amount)
            {
                return false;
            }

            //move money
            if (!accountDAO.Withdrawal(transfer))
            {
                return false;
            }
            if (!accountDAO.Deposit(transfer))
            {
                return false;
            }

            //get destination account for logging
            Account targetAccount = accountDAO.GetAccount(transfer.ToUser);

            //update transfer info
            Log log = new Log
            {
                FromId = sourceAccount.AccountId,
                ToId = targetAccount.AccountId,
                Amount = transfer.Amount,
                Type = TransferType.SEND,
                Status = StatusType.APPROVED
            };

            if (!transferDAO.AddTransfer(log))
            {
                return false;
            }

            return true;
        }

        [HttpPut("acceptrejectpending/{selection}")]
        public bool AcceptRejectPending(TransferRecord transfer, int selection)
        {
            Dictionary<int, int> accountToUser = accountDAO.AccountToUser();

            //does ID match request?
            int loggedinUserId = GetUserId();
            int sourceUserId = accountToUser[transfer.AccountFrom];
            if (loggedinUserId != sourceUserId)
            {
                return false;
            }

            //is this accept or reject (1 = accept, 2 = reject

            if (selection == 2)
            {
                //Reject
                //update transfer info
                Log log = new Log
                {
                    TransferId = transfer.TransferId,
                    FromId = transfer.AccountFrom,
                    ToId = transfer.AccountTo,
                    Amount = transfer.Amount,
                    Type = TransferType.REQUEST,
                    Status = StatusType.REJECTED
                };

                if (!transferDAO.UpdateTransfer(log))
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            else if (selection == 1)
            {
                //accept

                //is there enough money?
                Account sourceAccount = accountDAO.GetAccount(loggedinUserId);
                if (sourceAccount.Balance < transfer.Amount)
                {
                    return false;
                }

                //move money
                Transfer temp = new Transfer
                {
                    FromUser = sourceUserId,
                    ToUser = accountToUser[transfer.AccountTo],
                    Amount = transfer.Amount
                };

                if (!accountDAO.Withdrawal(temp))
                {
                    return false;
                }

                if (!accountDAO.Deposit(temp))
                {
                    return false;
                }

                //update transfer info
                Log log = new Log
                {
                    TransferId = transfer.TransferId,
                    FromId = transfer.AccountFrom,
                    ToId = transfer.AccountTo,
                    Amount = transfer.Amount,
                    Type = TransferType.REQUEST,
                    Status = StatusType.APPROVED
                };

                if (!transferDAO.UpdateTransfer(log))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                //invalid selection
                return false;
            }
        }

        [HttpGet("accounttouser")]
        public Dictionary<int, int> AccountToUser()
        {
            Dictionary<int, int> accountToUser = accountDAO.AccountToUser();
            return accountToUser;
        }

        [HttpGet("usertoname")]
        public Dictionary<int, string> UserToName()
        {
            Dictionary<int, string> userToName = accountDAO.UserToName();
            return userToName;
        }

        [HttpGet("typetoname")]
        public Dictionary<int, string> TypeToName()
        {
            Dictionary<int, string> userToName = accountDAO.TypeToName();
            return userToName;
        }

        [HttpGet("statustoname")]
        public Dictionary<int, string> StatusToName()
        {
            Dictionary<int, string> userToName = accountDAO.StatusToName();
            return userToName;
        }

        private bool Withdraw(Transfer transfer)
        {
            bool result = accountDAO.Withdrawal(transfer);
            return result;
        }

        private bool Deposit(Transfer transfer)
        {
            bool result = accountDAO.Deposit(transfer);
            return result;
        }

        private int GetUserId()
        {
            int id = -1;

            foreach (var claim in User.Claims)
            {
                if (claim.Type == "sub")
                {
                    id = int.Parse(claim.Value);
                }
            }
            return id;
        }
    }
}