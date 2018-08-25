using System;

namespace Eventum.Data
{
    public class Event : Entity
    {
        public string Title { get; set; }
        public int Guests { get; set; }
        public DateTime EventDate { get; set; }
        public bool Validated { get; set; } = false;
        public bool Premium { get; set; }
        public bool Closed { get; private set; } = false;

        public bool IsValid()
        {
            return IsValidDate()
                   &&
                   Validated;
        }

        private bool IsValidDate() =>
            (EventDate - DateTime.Now).Days >= 2;


        public void Close() => Closed = true;

        public void CloseValidadtePremium()
        {
            if (IsValidPremium())
                Closed = true;
        }

        public bool IsValidPremium()
        {
            return IsValid() || Premium;
        }
    }
}
