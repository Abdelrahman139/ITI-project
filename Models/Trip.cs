using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Train_Tickets.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        [NotMapped]
        public TimeSpan Duration => EndTime - StartTime;

        public int StartStationId { get; set; }

        [ForeignKey("StartStationId")]
        public virtual Station StartStation { get; set; }

      
        public int EndStationId { get; set; }

        [ForeignKey("EndStationId")]
        public virtual Station EndStation { get; set; }

      
        public int TrainId { get; set; }

        [ForeignKey("TrainId")]
        public virtual Train Train { get; set; }

        public virtual List<Ticket> Tickets { get; set; }
    }
}
