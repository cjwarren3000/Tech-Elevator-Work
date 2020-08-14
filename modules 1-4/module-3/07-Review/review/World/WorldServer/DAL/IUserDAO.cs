using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldServer.Models;

namespace WorldServer.DAL
{
    public interface IUserDAO
    {
        User GetUser(string username);
        User AddUser(string username, string password);
    }
}
