using Novus_Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novus_Catalog.Repository
{
    public interface IUserRepository
    {
        bool CheckUserPassword(string account, string password);
        int CheckUserPassword(string accountName, string oldpassword, string newpassword);
        Users FindByAccount(String account);
    }
}
