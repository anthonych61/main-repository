using Novus_Catalog.DAL;
using Novus_Catalog.Models;
using Novus_Catalog.Repository;
using Novus_Catalog.Services;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Novus_Catalog.Controllers
{
    public class RemoveController : Controller
    {
        private readonly IStudentService _service;

        public RemoveController()
        {
            var repo = new StudentRepository(); // or mock for testing
            _service = new StudentService(repo);
        }

        public RemoveController(IStudentService service)
        {
            _service = service;
        }

        /// <summary>
        /// A function of the database web application that will allow mentors and adminstrators
        /// of the system to remove student records from the system
        /// </summary>
        public JsonResult Delete(string id) 
        {
            var item = id.Split(',').Select(int.Parse).ToArray();

            // move records to students_deleted
            _service.MoveOldRecords(item);

            // delete records
            _service.Delete(item);  

            return Json(new { redirectToUrl = Url.Action("Student", "Default") });
        }
    }
}