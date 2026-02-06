public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();
    private List<string> _usedPrompts = new List<string>();
    private List<string> _usedQuestions = new List<string>();
    private int _reflectingDuration;
    private int _reflectingCount;
    public ReflectingActivity(string name, string description) 
        : base(name, description)
    {
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");

        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
    }

    public void Run()
    {
        DisplayStartingMessage();
        
        _reflectingCount += 1;
        _reflectingDuration += _duration;

        Console.WriteLine("\nConsider the following prompt:");
        DisplayPrompt();
        Console.WriteLine("When you have something on your mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            TimeSpan remainingTime = endTime - DateTime.Now;

            int timeLeft = (int)remainingTime.TotalSeconds;

            if (timeLeft >= 10)
            {
                DisplayQuestions();
                ShowSpinner(10);
            }
            else
            {
                DisplayQuestions();
                ShowSpinner(timeLeft+1);
            }
        }

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {

        Random random = new Random();

        if (_prompts.Count() <= 0 )
        {
            _prompts.AddRange(_usedPrompts);
            _usedPrompts.Clear();
        }
    
        int randomNumb = random.Next(0, _prompts.Count());
        _usedPrompts.Add(_prompts[randomNumb]);

        string randPrompt = $"--- {_prompts[randomNumb]} ---";
        _prompts.RemoveAt(randomNumb);

        return randPrompt;
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();

        if (_questions.Count() <= 0 )
        {
            _questions.AddRange(_usedQuestions);
            _usedQuestions.Clear();
        }
    
        int randomNumb = random.Next(0, _questions.Count());
        _usedQuestions.Add(_questions[randomNumb]);

        string randQuestion = $"\n> {_questions[randomNumb]} ";
        _questions.RemoveAt(randomNumb);

        return randQuestion;
    }

    public void DisplayPrompt()
    {
        Console.WriteLine(GetRandomPrompt());
    }

    public void DisplayQuestions()
    {
        Console.Write(GetRandomQuestion());
    }

     public string GetTotals()
    {
        if (_reflectingCount == 0)
        {
            return "";
        }
        else
        {
            return $"You have completed the {_name} Activity {_reflectingCount} times!\nYou have spent {_reflectingDuration} seconds on this activity.";
        }
    }
    
}
