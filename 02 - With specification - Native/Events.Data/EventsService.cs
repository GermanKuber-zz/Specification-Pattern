namespace Events.Data
{
    public class EventsService
    {
        private readonly EventsRepository _eventsRepository;

        public EventsService()
        {
            _eventsRepository = new EventsRepository();
        }

        public void CloseEvent(Event @event)
        {
            if (@event.Validated && @event.Guests > 15)
            {
                @event.Close();
                //_eventsRepository.Update(@event)
            }
        }

        public void CloseEventPremium(Event @event)
        {
            //TODO : 04 - Compilo la expression y la utilizo
            var eventIsValid = Event.IsValid.Compile();
            if (eventIsValid(@event) && @event.Premium)
            {
                @event.Close();
                //_eventsRepository.Update(@event)
            }
        }

        public void CloseValidatedPremium(Event @event)
        {
            @event.CloseValidadtePremium();
        }
    }
}