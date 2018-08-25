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
            using (var context = new EventsContext())
                return context.Events.Where(x => x.Guests >= minimumGuests).ToList();
        }





        public IReadOnlyList<Event> Get(int minimumGuests, bool validatedEvent)
        {
            using (var context = new EventsContext())
                return context.Events.Where(x => x.Guests >= minimumGuests
                                                 &&
                                                 x.Validated == validatedEvent).ToList();

        }





        public IReadOnlyList<Event> Get(int minimumGuests, bool validatedEvent, bool validDate)
        {
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
            //TODO: 08 - Combino Specifications con Validaciones
            var validEventSpecification = new ValidEventSpecification();
            var isPremiumEventSpecification = new IsPremiumEventSpecification();

            using (var context = new EventsContext())
                return context.Events.Where(x => x.Guests >= minimumGuests
                                              
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
            //TODO : 03 - Filtro en DB con la specification
            var validEventSpecification = new ValidEventSpecification();

            using (var context = new EventsContext())
                return context.Events.Where(validEventSpecification.ToExpression())
                    .ToList();
        }

        public IReadOnlyList<Event> GetValidEventToClose()
        {
            //TODO : 07 - Retorno los eventos validas listos para cerrar
            var validEventSpecification = new ValidEventSpecification();
            var eventToCloseSpecification = new EventToCloseSpecification();

            using (var context = new EventsContext())
                return context.Events.Where(validEventSpecification.And(eventToCloseSpecification).ToExpression())
                    .ToList();
        }
    }
}
