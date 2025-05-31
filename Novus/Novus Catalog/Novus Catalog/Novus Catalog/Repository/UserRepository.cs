using System.Linq;
using Novus_Catalog.DAL;
using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;

namespace Novus_Catalog.Repository
{
    public class UserRepository : IUserRepository
    {
        public bool CheckUserPassword(string account, string password)
        {
            var rowsReturned = 0;

            using (var _novusContext = new NovusContext())
            {
                rowsReturned =  (from usr in _novusContext.Users

                                    where usr.account == account && usr.password == password

                                    select new { usr.account, usr.password }).Count();

            }

            return (rowsReturned > 0) ? true : false;

        }

        public int CheckUserPassword(string accountName, string oldpassword, string newpassword)
        {
            var storedProcedureName = "usp_UpdateUserPassword";
            var constr = ConfigurationManager.ConnectionStrings["NovusContext"].ConnectionString;
            SqlParameter returnValueParam = new SqlParameter("returnVal", SqlDbType.Int);

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(storedProcedureName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Account", accountName);
                    cmd.Parameters.AddWithValue("@OldPassword", oldpassword);
                    cmd.Parameters.AddWithValue("@NewPassword", newpassword);

                    // set output parameter
                    returnValueParam.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnValueParam);

                    cmd.ExecuteNonQuery();
                    con.Close();                    

                }

            }

            return Convert.ToInt32(returnValueParam.Value.ToString());

        }
    }
}