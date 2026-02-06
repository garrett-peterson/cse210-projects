/*
    Exceeding Requirements:
    For the Listing and Reflecting activities I made sure you couldn't
    get the same prompt or question without going through all of them.

    And I added a menu option to see how many times you have completed
    each activity and how many seconds you have spent total on it.
*/



using System;

class Program
{
    static void Main(string[] args)
    {
        string breath = "This activity will help you relax by walking you through breathing in and out slowly.  Clear your mind and focus on your breathing.";
        string reflect = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        string listing = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        
        BreathingActivity breathingActivity = new BreathingActivity("Breathing", breath);
        ListingActivity listingActivity = new ListingActivity("Listing", listing);
        ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting", reflect);

        bool running = true;

        while (running) {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("   1. Start breathing activity");
            Console.WriteLine("   2. Start reflecting activity");
            Console.WriteLine("   3. Start listing activity");
            Console.WriteLine("   4. See your activity totals");
            Console.WriteLine("   5. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                breathingActivity.Run();
            }
            else if (choice == "2")
            {
                reflectingActivity.Run();
            }
            else if (choice == "3")
            {
                listingActivity.Run();
            }
            else if (choice == "5")
            {
                running = false;
            }
            else if (choice == "4")
            {
                Console.WriteLine(breathingActivity.GetTotals());
                Console.WriteLine();
                Console.WriteLine(listingActivity.GetTotals());
                Console.WriteLine();
                Console.WriteLine(reflectingActivity.GetTotals());
                Thread.Sleep(10000);
            }
            else
            {
                Console.WriteLine("Please enter a valid choice");
            }
        }
    }
}