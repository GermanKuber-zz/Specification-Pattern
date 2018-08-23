﻿using System;

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