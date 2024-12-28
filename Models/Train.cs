namespace Train_Tickets.Models
{
    public class Train
    {
        public int Id { get; set; }  
        public string Model { get; set; }  

    
        public virtual List<Trip> Trips { get; set; }
    }
}
