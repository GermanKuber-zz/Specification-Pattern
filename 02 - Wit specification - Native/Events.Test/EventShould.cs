using System;
using Events.Data;
using FluentAssertions;
using Xunit;

namespace Events.Test
{
    public class EventShould
    {
        private  Event _sut;

        public EventShould()
        {
            _sut = new Event
            {
                EventDate = DateTime.Now.AddDays(1),
                Validated = true
            };
        }

        [Fact]
        public void Be_Invalid()
        {
            _sut.IsValid().Should().Be(false);
        }

        [Fact]
        public void Be_Valid()
        {
            _sut = new Event
            {
                EventDate = DateTime.Now.AddDays(3),
                Validated = true
            };
            _sut.IsValid().Should().Be(true);
        }
    }
}