using ClosedXML.Excel;
using Novus_Catalog.DAL;
using Novus_Catalog.Models;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Novus_Catalog.Controllers
{
    public class ReportController : Controller
    {
        private NovusContext db = new NovusContext();

        /// <summary>
        /// A function that will allow administrative users to export 
        /// documents in a excel format that could be used for data manipulation 
        /// and/or analytics purposes
        /// </summary>
        public ActionResult GenerateReport(string id)
        {
            var item = id.Split(',').Select(int.Parse).ToArray();

            DataTable dt = new DataTable("Student Report");
            dt.Columns.AddRange(new DataColumn[13] { new DataColumn("SID"),
                        new DataColumn("SFirstname"), new DataColumn("SLastname"), new DataColumn("Gender"), new DataColumn("Address"),
                        new DataColumn("City") , new DataColumn("Department"), new DataColumn("School"), new DataColumn("PFirstname"),
                        new DataColumn("PLastname"), new DataColumn("PhoneNumber"), new DataColumn("DateEnrollment"), 
                        new DataColumn("Attendance") });

            var students = from student in db.Students
                           where item.Contains(student.sid)
                           select student;

            foreach (var student in students)
            {
                dt.Rows.Add( student.sid, student.sfirstname, student.slastname,student.gender, student.address, 
                student.city, student.department, student.school, student.pfirstname, student.plastname, 
                student.phoneNumber, student.dateEnrolled, student.attendance );
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    TempData["Output"] = stream.ToArray();
                }
            }
            // returns successful state
            return Json("Success", JsonRequestBehavior.AllowGet);

        }

        public ActionResult DownloadFile()
        {
            // retrieve stream here
            var array = TempData["Output"] as byte[];  
            if (array != null)
            {
                return File(array, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", string.Format("{0}_{1}.xls", "StudentReport", DateTime.Now.ToString("yyyyMMddhmmss")));
            }
            else
            {
                return new EmptyResult();
            }

        }

    }

}