namespace Events.Data
{
    public class EventsService
    {
        private readonly EventsRepository _eventsRepository;

        public EventsService()
        {
            _eventsRepository = new EventsRepository();
        }
      
    }
}