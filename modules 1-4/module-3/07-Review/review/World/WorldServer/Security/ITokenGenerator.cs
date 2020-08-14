using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldServer.Security
{
    public interface ITokenGenerator
    {
        string GenerateToken(int userId, string username, string role);
    }
}
