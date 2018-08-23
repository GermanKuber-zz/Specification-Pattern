﻿using System;
using System.Linq.Expressions;

namespace Events.Data
{
    public class Event : Entity
    {
        //TODO : 01 - Implemento una expression
        public static readonly  Expression<Func<Event, bool>> IsValid =
            x => (x.EventDate - DateTime.Now).Days >= 2
                 &&
                 x.Validated;

        public string Title { get; set; }
        public int Guests { get; set; }
        public DateTime EventDate { get; set; }
        public bool Validated { get; set; } = false;
        public bool Premium { get; set; }
        public bool Closed { get; private set; } = false;


        public void Close() => Closed = true;

        public void CloseValidadtePremium()
        {
            //TODO : 02 - Compilo la expression y la utilizo
            var eventIsValid = Event.IsValid.Compile();
            if (eventIsValid(this) && Validated && Premium)
                Closed = true;
        }
    }
}
