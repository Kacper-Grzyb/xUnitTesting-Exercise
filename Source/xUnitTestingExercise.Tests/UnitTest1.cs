using MyEvents.Tests;

namespace xUnitTestingExercise.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        EventTests test = new EventTests();
        test.RegisterAttendee_ReturnsFalse_WhenEventIsFull();
        test.RegisterAttendee_DecreasesCapacity(100);
    }
}