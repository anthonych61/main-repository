using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Novus_Catalog.Models
{
    public class Users
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string account { get; set; }

        [Required]
        public string password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Password required.")]
        public string oldMentorPwd { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Password required.")]
        public string newMentorPwd { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Password required.")]
        public string oldAdminPwd { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Password required.")]
        public string newAdminPwd { get; set; }

        public Users() { }

        public Users(string account, string password)
        {
            this.account = account;
            this.password = password;
        }

    }
}