using Novus_Catalog.DAL;
using Novus_Catalog.Models;
using Novus_Catalog.Repository;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Novus_Catalog.Controllers
{
    public class EditController : Controller
    {
        private NovusContext db = new NovusContext();

        [HttpPost]
        public ActionResult User()
        {
            return RedirectToAction("Student", "Default");
        }

        /// <summary>
        /// A function of the database web application that will allow mentors and adminstrators
        /// of the system to modify student records from the system
        /// </summary>
        public ActionResult Student(int? id)
        {
            var std = db.Students.Where(s => s.sid == id).FirstOrDefault();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Students student = db.Students.Find(id);

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(std);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Student([Bind(Include = "sid, sfirstname, slastname, gender, address, city, department, school, pfirstname, plastname, phoneNumber, dateEnrolled, attendance, createdDateTime, modifiedDateTime")] Students student)
        {
            StudentRepository s = new StudentRepository();

            DateTime currentTime = DateTime.Now;
            student.createdDateTime = currentTime;
            student.modifiedDateTime = currentTime;

            if (ModelState.IsValid)
            {               
                s.SaveModifiedRecords(db, student);
                
                return RedirectToAction("Student", "Default");
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                                       .Where(y => y.Count > 0)
                                       .ToList();
            }

            return View(student);
        }

    }
}