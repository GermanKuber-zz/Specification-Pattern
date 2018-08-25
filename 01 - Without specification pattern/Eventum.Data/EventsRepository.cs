using System;
using System.Collections.Generic;
using System.Linq;

namespace Eventum.Data
{
    public class EventsRepository
    {


        public IReadOnlyList<Event> Get(int minimumGuests)
        {
            //TODO: 01 - Se debe poder filtrar por cantidad minima de invitados
            using (var context = new EventsContext())
                return context.Events.Where(x => x.Guests >= minimumGuests)
                                     .ToList();
        }





        public IReadOnlyList<Event> GetValid(int minimumGuests)
        {
            //TODO: 02 - Se debe poder filtrar por eventos Validados
            using (var context = new EventsContext())
                return context.Events.Where(x => x.Guests >= minimumGuests
                                                 &&
                                                 x.Validated)
                                     .ToList();
        }

        public IReadOnlyList<Event> GetValidDate(int minimumGuests)
        {
            //TODO: 03 - Se debe poder filtrar por un evento con fecha valida

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
            //TODO: 04 - Se debe poder filtrar por eventos premium (Si son premium no importa si la fecha es valida)

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
            //TODO: 07 - Implementar filtros desde metodos de clase

            using (var context = new EventsContext())
                return context.Events.Where(x => x.Guests >= minimumGuests
                                                 &&
                                                 x.IsValid()
                                                 ||
                                                 x.Premium)
                    .ToList();
        }

        public IReadOnlyList<Event> GetValidEventPremium(int minimumGuests)
        {
            //TODO: 09 - Implementar consulta encapsulada

            using (var context = new EventsContext())
                return context.Events.Where(x => x.Guests >= minimumGuests
                                                 &&
                                                 x.IsValidPremium())
                                     .ToList();
        }
    }
}
