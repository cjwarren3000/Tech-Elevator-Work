using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface ITransferDAO
    {
        List<Transfer> GetTranfersForUser(int userId);
        List<Transfer> GetPendingTransfersForUser(int userId);
        Transfer CreateTransfer(Transfer newTransfer);
        Transfer UpdateTransfer(Transfer updatedTransfer);
    }
}
