using System;
using System.Collections.Generic;
using System.Linq;
using Eventum.Data.Specification;

namespace Eventum.Data
{
    public class EventsRepository
    {


        public IReadOnlyList<Event> Get(int minimumGuests)
        {
            //TODO : 06 - Filtro con specification
            var minimumGuestsEventSpecification = new MinimumGuestsEventSpecification(minimumGuests);
            using (var context = new EventsContext())
                return context.Events.Where(minimumGuestsEventSpecification.ToExpression())
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
            //TODO : 07 - Concateno specifications
            var minimumGuestsEventSpecification = new MinimumGuestsEventSpecification(minimumGuests);
            var validEventSpecification = new ValidEventSpecification();
            var isPremiumEventSpecification = new IsPremiumEventSpecification();
            
            using (var context = new EventsContext())
                return context.Events.Where(minimumGuestsEventSpecification
                                                        .And(validEventSpecification)
                                                        .Or(isPremiumEventSpecification)
                                                        .ToExpression())
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
