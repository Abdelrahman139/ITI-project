using Microsoft.AspNetCore.Mvc;
using Train_Tickets.Models;

namespace Train_Tickets.Controllers
{
    public class StationController : Controller
    {


        private readonly ProjectContext context;

        public StationController()
        {

            this.context = new ProjectContext();
        }


        public IActionResult Index()
        {
            List<Station> stations = context.Stations.ToList();
            return View(stations);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Station station)
        {

            context.Stations.Add(station);
            context.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Edit(int Id)
        { 
            Station station =context.Stations.SingleOrDefault(st => st.Id == Id);   
            return View(station); 
        }

        [HttpPost]
        public IActionResult Edit(int Id, string Name)
        {
            Station station =context.Stations.SingleOrDefault(s => s.Id == Id);

            station.Name = Name;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            Station? station =context.Stations.SingleOrDefault(st => st.Id == id);
            context.Stations.Remove(station);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
