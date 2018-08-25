using System;
using Eventum.Data;
using FluentAssertions;
using Xunit;

namespace Eventum.Test
{
    public class EventsServiceShould
    {
        private readonly EventsService _sut;

        public EventsServiceShould()
        {
            _sut = new EventsService();
        }

        [Fact]
        public void Close_Event()
        {
            var eventToCreate = new Event
            {
                Validated = true,
                Guests = 16,
                EventDate = DateTime.Now.AddDays(5)
            };
            _sut.CloseEvent(eventToCreate);
            eventToCreate.Closed.Should().Be(true);
        }

        [Fact]
        public void Close_Event_Premium()
        {
            var eventToCreate = new Event
            {
                EventDate = DateTime.Now.AddDays(7),
                Validated = true,
                Premium = true
            };
            _sut.CloseEventPremium(eventToCreate);
            eventToCreate.Closed.Should().Be(true);
        }

        [Fact]
        public void Close_Validated_Event_Premium()
        {
            var eventToCreate = new Event
            {
                EventDate = DateTime.Now.AddDays(7),
                Validated = true,
                Premium = true
            };
            _sut.CloseValidatedPremium(eventToCreate);
            eventToCreate.Closed.Should().Be(true);
        }
    }
}
