using System;
using Eventum.Data;
using FluentAssertions;
using Xunit;

namespace Eventum.Test
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
        public void Be_Valid()
        {
            _sut = new Event
            {
                EventDate = DateTime.Now.AddDays(3),
                Validated = true
            };
            Event.IsValid.Compile()(_sut).Should().Be(true);
        }
    }
}