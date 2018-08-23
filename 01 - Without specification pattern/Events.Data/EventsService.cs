﻿namespace Events.Data
{
    public class EventsService
    {
        private readonly EventsRepository _eventsRepository;

        public EventsService()
        {
            _eventsRepository = new EventsRepository();
        }

        //TODO: 06 - Para cerrar un evento este debe estar validado y  tener mas de 15 invitados
        public void CloseEvent(Event @event)
        {
            if (@event.Validated && @event.Guests > 15)
            {
                @event.Close();
                //_eventsRepository.Update(@event)
            }
        }
        //TODO: 07 - Para cerrar eventos premium (deben de ser premium y  deben ser validos)

        public void CloseEventPremium(Event @event)
        {
            if (@event.IsValid() && @event.Premium)
            {
                @event.Close();
                //_eventsRepository.Update(@event)
            }
        }
        //TODO: 08 - Para cerrar eventos premium (deben de ser premium y  deben ser validos)
        public void CloseValidatedPremium(Event @event)
        {
            @event.CloseValidadtePremium();
        }
    }
}