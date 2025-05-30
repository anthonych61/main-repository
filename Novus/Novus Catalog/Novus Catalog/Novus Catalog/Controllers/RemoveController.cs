using Novus_Catalog.DAL;
using Novus_Catalog.Models;
using Novus_Catalog.Repository;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Novus_Catalog.Controllers
{
    public class RemoveController : Controller
    {
        private NovusContext db = new NovusContext();

        /// <summary>
        /// A function of the database web application that will allow mentors and adminstrators
        /// of the system to remove student records from the system
        /// </summary>
        public JsonResult Delete(string id) 
        {
            StudentDeletedRepository s = new StudentDeletedRepository();

            var item = id.Split(',').Select(int.Parse).ToArray();

            // move records to students_deleted
            s.MoveOldRecords(db, item);

            // delete records
            s.DeleteRecords(db, item);  

            return Json(new { redirectToUrl = Url.Action("Student", "Default") });
        }
    }
}