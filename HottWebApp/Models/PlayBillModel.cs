namespace HottWebApp.Models
{
    public class PlayBillModel
    {
        public Event[] Events { get; private set; }
        public Event SelectedEvent { get; set; }

        public PlayBillModel(Event[] events)
        {
            Events = events;
        }
    }
}