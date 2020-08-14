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
    public class TransfersController : ControllerBase
    {
        private readonly ITransferDAO transferDAO;

        public TransfersController(ITransferDAO _transferDAO)
        {
            transferDAO = _transferDAO;
        }

        [HttpGet]
        public List<Transfer> GetTransfersForUser()
        {
            int userId = -1;
            foreach (var claim in User.Claims)
            {
                if (claim.Type == "sub")
                {
                    userId = int.Parse(claim.Value);
                }
            }
            List<Transfer> transfersForUser = transferDAO.GetTranfersForUser(userId);
            return transfersForUser;
        }

        [HttpGet("Pending")]
        public List<Transfer> GetPendingTransfersForUser()
        {
            int userId = -1;
            foreach (var claim in User.Claims)
            {
                if (claim.Type == "sub")
                {
                    userId = int.Parse(claim.Value);
                }
            }
            List<Transfer> transfersForUser = transferDAO.GetPendingTransfersForUser(userId);
            return transfersForUser;
        }

        [HttpPut("Pending")]
        public ActionResult<Transfer> UpdatePendingTeRequest(Transfer pendingTransfer)
        {
            Transfer updatedTransfer = transferDAO.UpdateTransfer(pendingTransfer);
            if (updatedTransfer == null)
            {
                return NotFound("Transfer does not exist");
            }
            return Ok(updatedTransfer);
        }
        [HttpPost]
        public ActionResult<Transfer> CreateTransfer(Transfer newTransfer)
        {
            Transfer createdTransfer = transferDAO.CreateTransfer(newTransfer);
            return Created($"/Transfers/{createdTransfer.transferId}", createdTransfer);
        }
    }
}