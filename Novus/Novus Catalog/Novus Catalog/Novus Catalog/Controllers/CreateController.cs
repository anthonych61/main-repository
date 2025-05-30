using Novus_Catalog.DAL;
using Novus_Catalog.Models;
using Novus_Catalog.Repository;
using Novus_Catalog.Services;
using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace Novus_Catalog.Controllers
{
    public class CreateController : Controller
    {
        [HttpPost]
        public ActionResult User()
        {
            return RedirectToAction("Student", "Default");
        }

        /// <summary>
        /// A function of the database web application that allows mentors and administrators
        /// of the system to create student records in the system
        /// </summary>
        public ActionResult Student()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Student([Bind(Include = "null, sfirstname, slastname, gender, address, city, department, school, pfirstname, plastname, phoneNumber, dateEnrolled, attendance, createdDateTime, modifiedDateTime")]Students student)
        {
            try
            {
                StudentService  studentService = new StudentService();

                DateTime currentTime = DateTime.Now;
                student.createdDateTime = currentTime;
                student.modifiedDateTime = currentTime;

                if (ModelState.IsValid)
                {                   
                    studentService.Save(student);

                    return RedirectToAction("Student", "Default");
                }
                else
                {
                    var errors = ModelState.Select(x => x.Value.Errors)
                                           .Where(y => y.Count > 0)
                                           .ToList();
                }

            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(student);
        }

    }
}