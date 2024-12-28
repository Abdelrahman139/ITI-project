using Microsoft.AspNetCore.Mvc;
using Train_Tickets.Models;
using Train_Tickets.ViewModels;
namespace Train_Tickets.Controllers
{
    public class AccountController : Controller
    {


        private readonly ProjectContext context;

        public AccountController()
        {

            this.context = new ProjectContext();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginVM Login)
        {
            User? user = context.Users.Where(x => x.Email == Login.Email && x.Password == Login.Password).SingleOrDefault();
            if (user == null)
            {
                TempData["invalid"] = "Worng email or password";
                return View("Login");
            }
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetString("Role", user.Role);
            HttpContext.Session.SetInt32("UserId", user.Id);

            return RedirectToAction("Index","Home");
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Name = registerVM.Name,
                    Email = registerVM.Email,
                    Password = registerVM.Password,
                    Role="User"
                   
                };


                context.Users.Add(user);
                context.SaveChanges();


                return RedirectToAction("Login");
            }


            return Content("invalid data");
        }



        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }





        public IActionResult Index()
        {
            return View();
        }








    }
}
