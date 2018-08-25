using Eventum.Data;
using FluentAssertions;
using Xunit;

namespace Eventum.Test
{
    public class EventsRepositoryShould
    {
        private readonly EventsRepository _sut;

        public EventsRepositoryShould()
        {
            _sut = new EventsRepository();
        }

        [Fact]
        public void Return_Valid_Event_With_Method()
        {
            var result = _sut.GetValidEvent(1);
            result.Count.Should().Be(1);
        }
    }
}