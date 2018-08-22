using System.Linq;
using Events.Data;
using FluentAssertions;
using Xunit;

namespace Events.Test
{
    public class EventsRepositoryShould
    {
        private readonly EventsRepository _sut;

        public EventsRepositoryShould()
        {
            _sut = new EventsRepository();
        }
        [Fact]
        public void Return_Valid_Event()
        {
            var result = _sut.Get(1, false, true);
            result.First().Id.Should().Be(1);
            result.Count.Should().Be(1);
        }

        [Fact]
        public void Return_No_Valid_Event()
        {
            var result = _sut.Get(1, false, false);
            result.Count.Should().Be(2);
        }
        [Fact]
        public void Return_Premium_And_Valid_Event()
        {
            var result = _sut.Get(1, false, true, true);
            result.Count.Should().Be(2);
        }

        [Fact]
        public void Return_Valid_Event_With_Method()
        {
            var result = _sut.GetValidEvent(1, true, true);
        }
    }
}