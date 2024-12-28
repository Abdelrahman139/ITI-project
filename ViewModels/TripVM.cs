using System.ComponentModel.DataAnnotations;
using Train_Tickets.Models;

namespace Train_Tickets.ViewModels
{
    public class TripVM
    {

       public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Duration")]
        public TimeSpan Duration => EndTime - StartTime;

        [Required]
        public int StartStationId { get; set; }

        [Required]
        public int EndStationId { get; set; }

        public Station StartStationName { get; set; }
        public Station EndStationName { get; set;}

        [Required]
        public int TrainId { get; set; }

     
        public List<Station> Stations { get; set; }
        public List<Train> Trains { get; set; }
    }
}
