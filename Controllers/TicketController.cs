using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Train_Tickets.Models;

namespace Train_Tickets.Controllers
{
    public class TicketController : Controller
    {

        private readonly ProjectContext context;

        public TicketController()
        {

            this.context = new ProjectContext();
        }


        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId").Value;
            var tickets = context.Tickets
                .Include(t => t.Trip)
                    .ThenInclude(trip => trip.StartStation)
                .Include(t => t.Trip)
                    .ThenInclude(trip => trip.EndStation)
                .Include(t => t.Trip)
                .Where(x => x.UserId == userId)
                .ToList();
            return View(tickets);
        }


        public IActionResult Create(int Id)

        {
          
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return View("Register");
            }

            Trip trip = context.Trips.Include(t => t.StartStation)
                .Include(t => t.EndStation)
                .Include(t => t.Train).FirstOrDefault(x => x.Id == Id);
                
            
            
          
           
            var userId = HttpContext.Session.GetInt32("UserId").Value;
            var user=context.Users.SingleOrDefault(x => x.Id == userId);
            Ticket ticket = new Ticket
            {
                  TicketNumber = "20",
                   UserId = userId,
                   User=user,
                   StartTime=trip.EndTime,
                   TripId = Id,
                   Trip = trip
                  };

            context.Tickets.Add(ticket);
            context.SaveChanges();
          
            TempData["SuccessMessage"] = "Ticket purchased successfully!";
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int Id)
        {
            var ticket =context.Tickets.SingleOrDefault(x => x.Id == Id);

            context.Tickets.Remove(ticket);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
