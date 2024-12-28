using System.ComponentModel.DataAnnotations.Schema;

namespace Train_Tickets.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }

       
        public virtual List<Trip> StartTrips { get; set; } = new List<Trip>();

        public virtual List<Trip> EndTrips { get; set; } = new List<Trip>();
    }
}
