public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;


    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity");
        Console.WriteLine();
        Console.WriteLine($"{_description}");
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like your session to be? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        
        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);

    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(4);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name} Activity");
        ShowSpinner(4);
        Console.Clear();
    }
    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string>{"|", "/", "-", "\\"};

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = spinner[i];
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");

            i++;

            if (i >= spinner.Count)
            {
                i = 0;
            }
        }
    }
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i --)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}