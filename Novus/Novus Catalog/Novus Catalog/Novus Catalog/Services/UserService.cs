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
        public int ChangeUserPassword(string accountName, string oldpassword, string newpassword)
        {
            return _repository.CheckUserPassword(accountName, oldpassword, newpassword);
        }
    }
}