using System;

namespace Events.Data
{
    public class Event : Entity
    {
        public string Title { get; set; }
        public int Guests { get; set; }
        public DateTime EventDate { get; set; }
        public bool Validated { get; set; } = false;
        public bool Premium { get; set; }

        public bool IsValid()
        {
            return (EventDate - DateTime.Now).Days >= 2
                &&
                Validated;
        }
    }
}
