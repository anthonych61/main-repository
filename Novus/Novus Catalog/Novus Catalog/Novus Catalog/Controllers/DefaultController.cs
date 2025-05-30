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
        // GET: Default
        public ActionResult Student()
        {
            StudentService studentService = new StudentService();

            var DisplayRecords = studentService.GetStudentRecords();
         
            return View(DisplayRecords);  
        }
    }
}