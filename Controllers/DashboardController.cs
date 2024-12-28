using Microsoft.AspNetCore.Mvc;
using Train_Tickets.Models;

namespace Train_Tickets.Controllers
{
    public class DashboardController : Controller
    {
            private readonly ProjectContext context;

            public DashboardController()
            {

                this.context = new ProjectContext();
            }



            public IActionResult Index()
            {
               
                 return View();
            }




    }
}
