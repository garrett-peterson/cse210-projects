using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");
        string running = "yes";

        while (running == "yes")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine();
                Prompt prompt = new Prompt();
                prompt.GetPrompt();
                Console.Write("> ");
                string entry = Console.ReadLine();
                Console.WriteLine();
                DateTime theCurrentTime = DateTime.Now;
                string dateText = theCurrentTime.ToShortDateString();   
                Console.WriteLine(dateText);

                //Possibly add the entry to a list that the display can then print
            }
            else if (choice == "2")
            {
                Console.WriteLine("You chose to Display");
                Console.WriteLine();
            }
            else if (choice == "3") {
                Console.WriteLine("You chose to Load");
                Console.WriteLine();
            }
             else if (choice == "4") {
                Console.WriteLine("You chose to Save");
                Console.WriteLine();
            }
             else if (choice == "5")
            {
                running = "no";
            }
            else
            {
                Console.WriteLine("Please enter a valid option");
                Console.WriteLine();
            }
        }
        

    }
}