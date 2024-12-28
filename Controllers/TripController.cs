using Microsoft.AspNetCore.Mvc;
using Train_Tickets.Models;
using Train_Tickets.Controllers;
using Microsoft.EntityFrameworkCore;
using Train_Tickets.ViewModels;
using System;
namespace Train_Tickets.Controllers
{
    public class TripController : Controller
    {



        private readonly ProjectContext context;

        public TripController()
        {

            this.context = new ProjectContext();
        }


        public IActionResult Index()
        {
            var trips = context.Trips
                .Include(t => t.StartStation)
                .Include(t => t.EndStation)
                .Include(t => t.Train)
            .ToList();
            ViewBag.Stations = context.Stations.ToList();


            return View(trips); 
        }

        public IActionResult Dashboard()
        {
            var trips = context.Trips
                .Include(t => t.StartStation)
                .Include(t => t.EndStation)
                .Include(t => t.Train)
            .ToList();

          return View("Dashboard", trips);
           
        }

        public IActionResult Details(int id)
        {
            Trip? Trip = context.Trips.Where(x => x.Id == id).SingleOrDefault();

         

            return View(Trip);


        }

         

        public IActionResult Create()
        {
            var viewModel = new TripVM
            {
                Stations = context.Stations.ToList(),
                Trains =  context.Trains.ToList()
            };
            return View(viewModel);
        }

       
        [HttpPost]
     
        public IActionResult Create(TripVM viewModel)
        {

            {
               
                var startStation = context.Stations.Find(viewModel.StartStationId);
                var endStation = context.Stations.Find(viewModel.EndStationId);
                var train = context.Trains.Find(viewModel.TrainId);

                

                var trip = new Trip
                {
                    Price = viewModel.Price,
                    StartTime = viewModel.StartTime,
                    EndTime = viewModel.EndTime,
                    StartStationId = viewModel.StartStationId,
                    EndStationId = viewModel.EndStationId,
                    TrainId = viewModel.TrainId,
                    StartStation = startStation,
                    EndStation = endStation,
                    Train = train
                };

                context.Trips.Add(trip);
                context.SaveChanges();
                TempData["Message"] = "Trip Created successfully!";
                return RedirectToAction("Dashboard");

            }
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Trip? trip = context.Trips
                .Include(t => t.StartStation)
                .Include(t => t.EndStation)
                .Include(t => t.Train)
                .SingleOrDefault(x => x.Id == id);

         

            var tripVM = new TripVM
            {
                Id = trip.Id,
                Price = trip.Price,
                StartTime = trip.StartTime,
                EndTime = trip.EndTime,
                StartStationId = trip.StartStationId,
                EndStationId = trip.EndStationId,
                TrainId = trip.TrainId,
                Stations = context.Stations.ToList(),
                Trains = context.Trains.ToList()
            };

            return View(tripVM);
        }


        [HttpPost]
        public IActionResult Edit(Trip trip1)
        {
            Trip? trip = context.Trips.SingleOrDefault(x => x.Id == trip1.Id);
          

             
            trip.Price = trip1.Price;
            trip.StartTime = trip1.StartTime;
            trip.EndTime = trip1.EndTime;
           trip.StartStationId = trip1.StartStationId;
            trip.EndStationId = trip1.EndStationId;
            trip.TrainId = trip1.TrainId;
            TempData["Message"] = "Trip Edited successfully!";
            context.SaveChanges();
            return RedirectToAction("Dashboard");
        }



        public IActionResult Delete(int Id)
        {
            Trip? trip = context.Trips.SingleOrDefault(x => x.Id == Id);
            
            context.Trips.Remove(trip);
            context.SaveChanges();

            TempData["Message"] = "Trip Deleted successfully!";
            return RedirectToAction("Dashboard");
        }

        public IActionResult Filter(int? Startstation, int? Endstation)
        {


            string k=Endstation.ToString();
        
            List<Trip> trips = context.Trips
                .Include(t => t.StartStation)
                .Include(t => t.EndStation)
                .Include(t => t.Train)
                .ToList();
           

            if(Startstation !=null)
            trips = trips.Where(x => x.StartStation.Id == Startstation).ToList();


            if (Endstation != null)
                trips = trips.Where(x =>x.EndStation.Id == Endstation).ToList();
           
            ViewBag.Stations = context.Stations.ToList();

            return View("Index",trips);
        }



    }
}
