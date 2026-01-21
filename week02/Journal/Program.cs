/*Exceeded Requirements
    I added two more menu options, 'Free Write' and 'Add Prompt'
    Free Write lets you write without a prompt.

    Add Prompt lets you enter a new prompt to add into the random 
    rotation of the other prompts.  I have all the prompts in a
    txt file that the Prompt.cs loads into a list, when the user
    enters a new prompt, the AddPrompt method of the Prompt.cs is
    called which then adds it to the list of prompts then writes the
    entire list of prompts back to the prompt txt file so the new
    prompt will stay when you run the program again.
*/



using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");
        string running = "yes";

        Journal theJournal = new Journal();
        Prompt prompt = new Prompt();
        
        Console.WriteLine(Directory.GetCurrentDirectory());
        while (running == "yes")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Free Write");
            Console.WriteLine("6. Add Prompt");
            Console.WriteLine("7. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine();

                Entry anEntry = new Entry();
                string promptText = prompt.GetRandomPrompt();
                Console.WriteLine(promptText);

                Console.Write("> ");
                string entry = Console.ReadLine();
                
                DateTime theCurrentTime = DateTime.Now;
                string dateText = theCurrentTime.ToShortDateString(); 

                anEntry._entryText = entry;
                anEntry._promptText = promptText;                 
                anEntry._date = dateText;

                theJournal.AddEntry(anEntry);

                Console.WriteLine();
            }
            else if (choice == "2")
            {
                Console.WriteLine();
                theJournal.DisplayAll();
            }
            else if (choice == "3") {

                Console.WriteLine();
                Console.WriteLine("What is the filename?");
                string fileName = Console.ReadLine();

                theJournal.LoadFromFile(fileName);
                Console.WriteLine();
            }
            else if (choice == "4") {
                Console.WriteLine("What is the filename?");
                string fileName = Console.ReadLine();

                theJournal.SaveToFile(fileName);
            }
            else if (choice == "5")
            {
                Console.WriteLine();

                Entry anEntry = new Entry();

                Console.Write("> ");
                string entry = Console.ReadLine();
                
                DateTime theCurrentTime = DateTime.Now;
                string dateText = theCurrentTime.ToShortDateString(); 

                anEntry._entryText = entry;
                anEntry._promptText = "Free Write";                 
                anEntry._date = dateText;

                theJournal.AddEntry(anEntry);

                Console.WriteLine();
            }
            else if (choice == "6")
            {
                Console.WriteLine();
                Console.WriteLine("What prompt do you want to add?");
                string newPrompt = Console.ReadLine();

                prompt.AddPrompt(newPrompt);
                Console.WriteLine();
            }
            else if (choice == "7")
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