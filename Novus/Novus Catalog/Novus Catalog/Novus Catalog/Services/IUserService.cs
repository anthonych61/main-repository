using Novus_Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novus_Catalog.Services
{
    public interface IUserService
    {
        bool UserExistsByAccountAndPassword(string account, string password);
        int ChangeUserPassword(Users user, string accountName, string oldpassword, string newpassword);
        Users FindByAccount(String account);
    }
}
