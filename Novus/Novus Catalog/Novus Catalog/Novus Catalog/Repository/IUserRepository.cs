using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novus_Catalog.Repository
{
    public interface IUserRepository
    {
        bool validateID(string account, string password);
        int ChangePassword(string accountName, string oldpassword, string newpassword);

    }
}
