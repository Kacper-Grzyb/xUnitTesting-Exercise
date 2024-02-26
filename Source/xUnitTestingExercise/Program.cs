using System;

namespace MyEvents;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Event Management System");

        // Create an instance of EventManager
        EventManager manager = new EventManager();

        // Create some sample events
        Event codingWorkshop = new Event("Coding Workshop", "Workshop", 30);
        Event techTalk = new Event("Tech Talk", "Seminar", 100);
        Event barbecue = new Event("Barbecue", "Food", 2);

        // Add events to the manager
        manager.AddEvent(codingWorkshop);
        manager.AddEvent(techTalk);

        // Display all events
        Console.WriteLine("Upcoming Events:");
        Console.WriteLine(codingWorkshop.ToString());
        Console.WriteLine(techTalk.ToString());

        // Simulate attendee registration
        Console.WriteLine("\nRegistering 1 attendee for the Coding Workshop...");
        bool registrationResult = codingWorkshop.RegisterAttendee();
        Console.WriteLine($"Registration successful: {registrationResult}");
        Console.WriteLine(codingWorkshop.ToString()); // Show updated capacity

        // Simulate adding to waitlist
        Console.WriteLine("\nRegistering 4 attendees for the Barbecue...");
        bool barbecueRegistrationResult = barbecue.RegisterAttendee();
        Console.WriteLine($"Registration 1 status: {barbecueRegistrationResult}");
        barbecueRegistrationResult = barbecue.RegisterAttendee();
        Console.WriteLine($"Registration 2 status: {barbecueRegistrationResult}");
        barbecueRegistrationResult = barbecue.RegisterAttendee();
        Console.WriteLine($"Registration 3 status: {barbecueRegistrationResult}");
        barbecueRegistrationResult = barbecue.RegisterAttendee();
        Console.WriteLine($"Registration 4 status: {barbecueRegistrationResult}");
        Console.WriteLine(barbecue.ToString()); // Show updated event with waiting list

        // Simulate event cancellation
        Console.WriteLine("\nCancelling the Tech Talk...");
        bool cancellationResult = manager.CancelEvent("Tech Talk");
        Console.WriteLine($"Cancellation successful: {cancellationResult}");
        Console.WriteLine(techTalk.ToString()); // Show updated status

        // Keep the console window open until the user presses a key
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}