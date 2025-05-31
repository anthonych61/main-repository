using System.Web.Mvc;
using Novus_Catalog.Models;
using Novus_Catalog.Repository;
using Novus_Catalog.Services;

namespace Novus_Catalog.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _service;

        public LoginController()
        {
            var repo = new UserRepository(); // or mock for testing
            _service = new UserService(repo);
        }

        public LoginController(IUserService service)
        {
            _service = service;
        }

        public ActionResult User()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult User(Users objUser)
        {
            var found = _service.UserExistsByAccountAndPassword(objUser.account, objUser.password);

            if (found)
            {
                Session["ACCOUNT"] = objUser.account.ToString();
                Session["PASS"] = objUser.password.ToString();
                return RedirectToAction("Student", "Default");
            }
            else
            {
                ModelState.AddModelError("", "The password you entered could not be found. Please try again.");
            }
            
            return View(objUser);

        }

    }
}
