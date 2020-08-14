using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface ITransferDAO
    {
        List<TransferRecord> GetTransfers(int userId);
        bool AddTransfer(Log log);
        bool UpdateTransfer(Log log);
    }
}
