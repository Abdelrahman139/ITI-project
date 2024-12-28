using Microsoft.AspNetCore.Mvc;
using Train_Tickets.Models;

namespace Train_Tickets.Controllers
{
    public class UserController : Controller
    {


        private readonly ProjectContext context;

        public UserController()
        {

            this.context = new ProjectContext();
        }



        public IActionResult Index()
        {
            List<User> users = context.Users.ToList();
            return View(users);
        }


        public IActionResult Details(int Id)
        {

           
         
            User? user1 = context.Users.Where(x => x.Id == Id).SingleOrDefault();

          

            return View(user1);


        }



        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user)
        {

            context.Users.Add(user);
            context.SaveChanges();
          
            TempData["Message"] = "User added successfully!";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            User? user = context.Users.SingleOrDefault(x => x.Id == id);
         
            return View(user);
        }


        [HttpPost]
        public IActionResult Edit(int Id, string Name, string Email, string Password)
        {
            User? user = context.Users.SingleOrDefault(x => x.Id == Id);
            if (user == null) return Content("NO such user , invalid id");

            user.Email = Email;
            user.Password = Password;
            user.Name = Name;
            
            TempData["Message"] = "User Edited successfully!";
            context.SaveChanges();

            return RedirectToAction("Details", new { Id = user.Id });
        }



        public IActionResult Delete(int Id)
        {
            User? user = context.Users.SingleOrDefault(x => x.Id == Id);
            
            context.Users.Remove(user);
            context.SaveChanges();
          
            TempData["Message"] = "User Deleted successfully!";
            return RedirectToAction("Index");
        }


       
        public IActionResult ChangeRole(int Id)
        {
            User? user = context.Users.SingleOrDefault(x => x.Id == Id);
           

            if (user.Role == "Admin")  {user.Role = "User"; }
            else {  user.Role = "Admin"; }
            
            context.SaveChanges();
            return RedirectToAction("Index");
        }





        public IActionResult Admin()
        {

            return Content("You are admin");
        }



      













    
    }
}
