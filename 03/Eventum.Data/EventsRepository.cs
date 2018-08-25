using System;
using System.Collections.Generic;
using System.Linq;

namespace Eventum.Data
{
    public class EventsRepository
    {


        public IReadOnlyList<Event> Get(int minimumGuests)
        {
            using (var context = new EventsContext())
                return context.Events.Where(x => x.Guests >= minimumGuests)
                                     .ToList();
        }


        
        public IReadOnlyList<Event> GetValid(int minimumGuests)
        {
            using (var context = new EventsContext())
                return context.Events.Where(x => x.Guests >= minimumGuests
                                                 &&
                                                 x.Validated)
                                     .ToList();
        }


        public IReadOnlyList<Event> GetValidDate(int minimumGuests)
        {
            using (var context = new EventsContext())
                return context.Events.Where(x => x.Guests >= minimumGuests
                                                 &&
                                                 x.Validated
                                                 &&
                                                 (x.EventDate - DateTime.Now).Days >= 2)
                                     .ToList();
        }

        public IReadOnlyList<Event> GetValidPremium(int minimumGuests)
        {
            using (var context = new EventsContext())
                return context.Events.Where(x => x.Guests >= minimumGuests
                                                 &&
                                                 ((x.Validated
                                                 &&
                                                 (x.EventDate - DateTime.Now).Days >= 2)
                                                 ||
                                                 x.Premium))
                                     .ToList();
        }




        public IReadOnlyList<Event> GetValidEvent(int minimumGuests)
        {
            //TODO : 03 - Realizo una query a la DB, mediante GenericSpecification
            var validSpecification
                = new GenericSpecification<Event>(x => (x.EventDate - DateTime.Now).Days >= 2
                                                       &&
                                                       x.Validated);

            using (var context = new EventsContext())
                return context.Events.Where(validSpecification.Expression)
                                     .ToList();
        }



        public IReadOnlyList<Event> GetValidEventPremium(int minimumGuests)
        {
            using (var context = new EventsContext())
                return context.Events.Where(x => x.Guests >= minimumGuests
                                                 &&
                                                 x.IsValidPremium())
                                     .ToList();
        }
    }
}
