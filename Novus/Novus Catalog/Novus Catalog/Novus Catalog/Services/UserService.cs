using Novus_Catalog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Novus_Catalog.Services
{
    public class UserService:IUserService
    {
        UserRepository userRepository = new UserRepository();

        public bool UserExistsByAccountAndPassword(string account, string password)
        {
            return userRepository.CheckUserPassword(account, password);
        }
        public int ChangeUserPassword(string accountName, string oldpassword, string newpassword)
        {
            return userRepository.CheckUserPassword(accountName, oldpassword, newpassword);
        }
    }
}