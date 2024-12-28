using System.ComponentModel.DataAnnotations.Schema;

namespace Train_Tickets.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; }


        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("TripId")]
        public int TripId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        public virtual User User { get; set; }
        public virtual Trip Trip { get; set; }

    }
}
