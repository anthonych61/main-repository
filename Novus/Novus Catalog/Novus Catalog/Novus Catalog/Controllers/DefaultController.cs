using Novus_Catalog.Models;
using Novus_Catalog.Repository;
using Novus_Catalog.Services;
using System.EnterpriseServices;
using System.Linq;
using System.Web.Mvc;

namespace Novus_Catalog.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IStudentService _service;

        public DefaultController() 
        {
            var repo = new StudentRepository(); // or mock for testing
            _service = new StudentService(repo);
        }

        public DefaultController(IStudentService service)
        {
            _service = service;
        }

        // GET: Default
        public ActionResult Student()
        {
            var DisplayRecords = _service.GetStudentRecords();
         
            return View(DisplayRecords);  
        }
    }
}