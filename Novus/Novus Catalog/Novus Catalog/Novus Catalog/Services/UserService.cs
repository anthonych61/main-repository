using Novus_Catalog.Models;
using Novus_Catalog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Novus_Catalog.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool UserExistsByAccountAndPassword(string account, string password)
        {
            return _repository.CheckUserPassword(account, password);
        }

        public int ChangeUserPassword(Users user, string accountName, string oldpassword, string newpassword)
        {
            if (newpassword != null) { user.password = newpassword; }

            return _repository.CheckUserPassword(accountName, oldpassword, newpassword);
        }

        public Users FindByAccount(String account)
        {
            return _repository.FindByAccount(account);
        }
    }
}