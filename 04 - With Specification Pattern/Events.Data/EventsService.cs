using System;

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
            //TODO : 06 - Valido el evento para poder ser cerrado
            var eventValidateToCloseSpecification = new EventToCloseSpecification();
            if (eventValidateToCloseSpecification.IsSatisfiedBy(@event))
            {
                @event.Close();
                //_eventsRepository.Update(@event)
            }
        }

        public void CloseEventPremium(Event @event)
        {
            //TODO : 05 - Filtro en memoria con la specification
            var validEventSpecification = new ValidEventSpecification();


            if (validEventSpecification.IsSatisfiedBy(@event) && @event.Premium)
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