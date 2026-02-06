public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>();
    private List<string> _usedPrompts = new List<string>();
    private int _listingDuration;
    private int _listingCount;

    public ListingActivity (string name, string description) 
        : base (name, description)
    {
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
    }

    public void Run()
    {
        DisplayStartingMessage();
        
        _listingCount +=1;
        _listingDuration += _duration;

        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        GetRandomPrompts();
        Console.Write("You may begin in: ");
        ShowCountDown(3);
        Console.Write("\n");

        List<string> input = GetListFromUser();
        _count = input.Count();

        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();

    }
    public void GetRandomPrompts()
    {   
        Random random = new Random();

        if (_prompts.Count() <= 0 )
        {
            _prompts.AddRange(_usedPrompts);
            _usedPrompts.Clear();
        }
    
        int randomNumb = random.Next(0, _prompts.Count());
        _usedPrompts.Add(_prompts[randomNumb]);
        Console.WriteLine($"--- {_prompts[randomNumb]} ---");
        _prompts.RemoveAt(randomNumb);
    }
    public List<string> GetListFromUser()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        List<string> answers = new List<string>();

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                answers.Add(input);
            }
        }
        
        return answers;
    }

    public string GetTotals()
    {
        if (_listingCount == 0)
        {
            return "";
        }
        else
        {
            return $"You have completed the {_name} Activity {_listingCount} times!\nYou have spent {_listingDuration} seconds on this activity.";
        }
       
    }
}