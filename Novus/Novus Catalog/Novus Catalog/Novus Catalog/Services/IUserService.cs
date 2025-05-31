using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novus_Catalog.Services
{
    internal interface IUserService
    {
        bool UserExistsByAccountAndPassword(string account, string password);
        int ChangeUserPassword(string accountName, string oldpassword, string newpassword);
    }
}
