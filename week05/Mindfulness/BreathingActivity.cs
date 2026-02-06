public class BreathingActivity : Activity
{
    private int _breathingDuration;
    private int _breathingCount;
    public BreathingActivity(string name, string description) 
        : base(name, description)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        _breathingCount +=1;
        _breathingDuration += _duration;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            TimeSpan remainingTime = endTime - DateTime.Now;

            int timeLeft = (int)remainingTime.TotalSeconds;
            
            if (timeLeft >= 12)
            {
                Console.Write("\nBreath in...");
                ShowCountDown(6);
                Console.Write("\nBreath out...");
                ShowCountDown(6);
                Console.WriteLine();
            }
            else if (timeLeft < 12)
            {
                int inhale = timeLeft/2;
                int exhale = timeLeft - inhale;

                Console.Write("\nBreath in...");
                ShowCountDown(inhale+1);
                Console.Write("\nBreath out...");
                ShowCountDown(exhale);
                Console.WriteLine();
            }
        }

        DisplayEndingMessage();
    }
            
    public string GetTotals()
    {
        if (_breathingCount == 0)
        {
            return "";
        }
        else
        {
            return $"You have completed the {_name} Activity {_breathingCount} times!\nYou have spent {_breathingDuration} seconds on this activity.";
        }
    }
    
}