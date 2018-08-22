using System;
using System.Collections.Generic;
using System.Linq;

namespace Events.Data
{
    public class EventsRepository
    {

        public Event GetById(int id)
        {
            using (var context = new EventsContext())
            {
                return context.Events.FirstOrDefault(x => x.Id == id);
            }
        }
        public IReadOnlyCollection<Event> GetAll()
        {
            using (var context = new EventsContext())
            {
                return context.Events.ToList();
            }
        }
        public IReadOnlyList<Event> Get()
        {
            using (var context = new EventsContext())
                return context.Events.ToList();
        }

        public IReadOnlyList<Event> Get(int minimumGuests)
        {
            //TODO: 01 - Se debe poder filtrar por cantidad minima de invitados
            using (var context = new EventsContext())
                return context.Events.Where(x => x.Guests >= minimumGuests).ToList();
        }





        public IReadOnlyList<Event> Get(int minimumGuests, bool validatedEvent)
        {
            //TODO: 02 - Se debe poder filtrar por evento Validado

            using (var context = new EventsContext())
                return context.Events.Where(x => x.Guests >= minimumGuests
                                                 &&
                                                 x.Validated == validatedEvent).ToList();

        }





        public IReadOnlyList<Event> Get(int minimumGuests, bool validatedEvent, bool validDate)
        {
            //TODO: 03 - Se debe poder filtrar por un evento con fecha valida

            using (var context = new EventsContext())
                return context.Events.Where(x => x.Guests >= minimumGuests
                                                 &&
                                                 x.Validated == validatedEvent
                                                 &&
                                                 ((validDate && (x.EventDate - DateTime.Now).Days >= 2)
                                                  ||
                                                  (!validDate && (x.EventDate - DateTime.Now).Days <= 2)))
                    .ToList();
        }





        public IReadOnlyList<Event> Get(int minimumGuests, bool validatedEvent, bool validDate, bool premium)
        {
            //TODO: 04 - Se debe poder filtrar por un evento premium, un evento premium siempre es valido por fecha

            using (var context = new EventsContext())
                return context.Events.Where(x => x.Guests >= minimumGuests
                                                 &&
                                                 x.Validated == validatedEvent
                                                 &&
                                                 ((validDate && (x.EventDate - DateTime.Now).Days >= 2)
                                                  ||
                                                  (!validDate && (x.EventDate - DateTime.Now).Days <= 2)
                                                  ||
                                                  premium == x.Premium))
                    .ToList();
        }

        public IReadOnlyList<Event> GetValidEvent(int minimumGuests, bool validDate, bool premium)
        {
            //TODO: 05 - Implementar filtros desde metodos de clase

            using (var context = new EventsContext())
                return context.Events.Where(x => x.Guests >= minimumGuests
                                                 &&
                                                 x.IsValid()
                                                 ||
                                                 premium == x.Premium)
                    .ToList();
        }
    }
}
