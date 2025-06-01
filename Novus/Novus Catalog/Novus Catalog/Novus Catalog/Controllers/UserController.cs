using Novus_Catalog.Models;
using Novus_Catalog.Repository;
using Novus_Catalog.Services;
using Novus_Catalog.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Web.Mvc;

namespace Novus_Catalog.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController()
        {
            var repo = new UserRepository(); // or mock for testing
            _service = new UserService(repo);
        }

        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpPost]
        public ActionResult User()
        {
            return RedirectToAction("Student", "Default");
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "oldMentorPwd, newMentorPwd, oldAdminPwd, newAdminPwd")] Users usr)
        {
            Boolean hasErrors = false;

            // check if any fields are blank
            if (String.IsNullOrEmpty(usr.oldMentorPwd) || String.IsNullOrEmpty(usr.newMentorPwd) || String.IsNullOrEmpty(usr.oldAdminPwd) || String.IsNullOrEmpty(usr.newAdminPwd))
            {
                hasErrors = true;            
            }

            if (!String.IsNullOrEmpty(usr.oldMentorPwd) && !String.IsNullOrEmpty(usr.newMentorPwd)) 
            {
                var mentorModifiedPwd = _service.ChangeUserPassword(usr, "Mentor", usr.oldMentorPwd, usr.newMentorPwd);

                if ( mentorModifiedPwd == 0)
                {
                    hasErrors = true;

                    ModelState.AddModelError("oldMentorPwd", "Password doesn't exist.");
                }

            }

            if (!String.IsNullOrEmpty(usr.oldAdminPwd) && !String.IsNullOrEmpty(usr.newAdminPwd))
            {
                var adminModifiedPwd = _service.ChangeUserPassword(usr, "Administrator", usr.oldAdminPwd, usr.newAdminPwd);

                if (adminModifiedPwd == 0)
                {
                    hasErrors = true;

                    ModelState.AddModelError("oldAdminPwd", "Password doesn't exist.");
                }

            }

            if(hasErrors)
            {
                ModelState.AddModelError("", "Please correct errors below.");
                return View(); // redirect to current page
            }

            return RedirectToAction("Student", "Default");

        }  

    }

}