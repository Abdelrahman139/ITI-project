using Microsoft.AspNetCore.Mvc;
using Train_Tickets.Models;

namespace Train_Tickets.Controllers
{
    public class TrainController : Controller
    {

        private readonly ProjectContext context;

        public TrainController()
        {

            this.context = new ProjectContext();
        }

        public IActionResult Index()
        {

            List<Train> trains = context.Trains.ToList();
            return View(trains);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Train train)
        {
          
                context.Trains.Add(train);
                context.SaveChanges();
                return RedirectToAction("Index");
           
           
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Train train = context.Trains.SingleOrDefault(st => st.Id == Id);
            return View(train);
        }

        [HttpPost]
        public IActionResult Edit(int Id, string Model)
        {
            Train train = context.Trains.SingleOrDefault(s => s.Id == Id);

            train.Model = Model;
            context.SaveChanges();
            return RedirectToAction("Index");
        }




        public IActionResult Delete(int Id) {
        
            Train train = context.Trains.SingleOrDefault( x => x.Id == Id ); 
            context.Trains.Remove(train);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
