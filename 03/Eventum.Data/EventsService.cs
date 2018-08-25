using System;

namespace Eventum.Data
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
            if (@event.Validated && (@event.EventDate - DateTime.Now).Days >= 2)
            {
                @event.Close();
                //_eventsRepository.Update(@event)
            }
        }

        public void CloseEventPremium(Event @event)
        {
            //TODO : 02 - Implemento validación mediante GenericSpecification
            var validSpecification
                = new GenericSpecification<Event>(x => (x.EventDate - DateTime.Now).Days >= 2
                                                       &&
                                                       x.Validated);

            if (validSpecification.IsSatisfiedBy(@event) && @event.Premium)
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