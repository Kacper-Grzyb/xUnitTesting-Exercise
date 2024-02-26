using Xunit;
using MyEvents;

namespace MyEvents.Tests
{
    public class EventTests
    {
        [Fact]
        public void Event_IsActive_WhenCreated()
        {
            var evnt = new Event("Code Workshop", "Workshop", 50);
            Assert.True(evnt.IsActive);
        }

        [Fact]
        public void CancelEvent_SetsIsActiveToFalse()
        {
            var evnt = new Event("Code Workshop", "Workshop", 50);
            evnt.Cancel();
            Assert.False(evnt.IsActive);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(1)]
        public void RegisterAttendee_DecreasesCapacity(int initialCapacity)
        {
            var evnt = new Event("Code Workshop", "Workshop", initialCapacity);
            bool registrationResult = evnt.RegisterAttendee();

            Assert.True(registrationResult);
            Assert.Equal(initialCapacity - 1, evnt.Capacity);
        }

        [Fact]
        public void RegisterAttendee_ReturnsFalse_WhenEventIsInactive()
        {
            var evnt = new Event("Code Workshop", "Workshop", 0);
            evnt.Cancel();
            bool registrationResult = evnt.RegisterAttendee();
            Assert.False(registrationResult);
        }

        [Fact]
        public void RemoveAttendee_ReturnsFalse_WhenNoPeopleRegistered()
        {
            var evnt = new Event("Code Workshop", "Workshop", 2);
            bool removalResult = evnt.RemoveAttendee();
            Assert.False(removalResult);
        }

        [Fact] 
        public void RemoveAttendee_DeductsFromWaitingList_WhenWaitingListIsEmpty()
        {
            var evnt = new Event("Code Workshop", "Workshop", 5);
            evnt.RegisterAttendee();
            evnt.RemoveAttendee();
            // registered and removed attendee, no one should have been removed from the waiting list so it should be at zero
            Assert.True(evnt.waitingList == 0);
        }
    }
}