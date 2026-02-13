using System.Drawing;
using System.Xml.Serialization;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;
    private string _titlePrefix;
    private string _titleSuffix;
    private string _title;
    private int _level;
    private List<Title> _prefixOptions = new List<Title>();
    private List<Title> _suffixOptions = new List<Title>();

    public GoalManager()
    {
        _score = 0;

        _level = 0;

        _titlePrefix =" ";
        _titleSuffix = "";
        _title = _titlePrefix + _titleSuffix;

        CreatePrefixOptions(); 
        CreateSuffixOptions();   
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            DisplayPlayerInfo();

            Console.WriteLine("Menu Options: ");
            Console.WriteLine("   1. Create New Goal");
            Console.WriteLine("   2. List Goals");
            Console.WriteLine("   3. Save Goals");
            Console.WriteLine("   4. Load Goals");
            Console.WriteLine("   5. Record Event");
            Console.WriteLine("   6. Spend Points");
            Console.WriteLine("   7. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "7")
            {
                running = false;
            }
            else if (choice == "6")
            {
                SpendPoints();
            }
            else
            {
                Console.Write("Select a valid choice from the menu: ");
            }
        }
        
    }

    public void DisplayPlayerInfo()
    {
        if (_title != " ")
        {
            Console.WriteLine($"\nYou have {_score} points {_title}");
            Console.WriteLine($"You are level {_level}\n");
        }
        else
        {
            Console.WriteLine($"\nYou have {_score} points");
            Console.WriteLine($"You are level {_level}\n");
        }
        
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The Goals Are:");
        int numb = 1;
        foreach (Goal g in _goals)
        {
            string name = g.GetShortName();
            Console.WriteLine($"{numb}. {name}");
            numb++;
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The Goals Are:");
        int numb = 1;
        foreach (Goal g in _goals)
        {   
            string goalText = g.GetDetailsString();
            Console.WriteLine($"{numb}. {goalText}");
            numb++;
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are: ");
        Console.WriteLine("   1. Simple Goal");
        Console.WriteLine("   2. Eternal Goal");
        Console.WriteLine("   3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();

        if (type == "3")
        {
            Console.Write("How many times does the goal need to be accomplished for a bonus? ");
            string target = Console.ReadLine();

            Console.Write("What is the bonus for accomplishing it that many times? ");
            string bonus = Console.ReadLine();

            ChecklistGoal check = new ChecklistGoal(name, description,  int.Parse(points), int.Parse(target), int.Parse(bonus));

            _goals.Add(check);
        }
        else if (type == "2")
        {
            EternalGoal eternal =  new EternalGoal(name, description,  int.Parse(points));
            _goals.Add(eternal);
        }

        else if (type == "1")
        {
            SimpleGoal simple = new SimpleGoal(name, description,  int.Parse(points));
            _goals.Add(simple);
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        
        Console.Write("Which did you accomplish? ");
        string answer = Console.ReadLine();
        
        int index = int.Parse(answer) - 1;

        bool wasComplete = _goals[index].IsComplete();

        _goals[index].RecordEvent();

        int points = _goals[index].ReturnScore(wasComplete);

        _score += points;

        if (wasComplete == false)
        {
            _level += 1;
        }

        Console.WriteLine($"Congratulations! You have earned {points} points!");
        Console.WriteLine($"You now have {_score} points.");
        Console.WriteLine($"You are now level {_level}");

    }

    public void SaveGoals()
    {

        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach(Goal g in _goals)
            {
                outputFile.WriteLine(g.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        foreach(string line in lines.Skip(1))
        {
            string[] values = line.Split(',');

            if (values[0] == "SimpleGoal")
            {
                SimpleGoal simple = new SimpleGoal(values[1], values[2], int.Parse(values[3]));
                _goals.Add(simple);
                if (values[4] == "True")
                {
                    simple.RecordEvent();
                }
            }
            else if (values[0] == "EternalGoal")
            {
                EternalGoal eternal = new EternalGoal(values[1], values[2], int.Parse(values[3]));
                _goals.Add(eternal);
            }
            else if (values[0] == "ChecklistGoal")
            {
                ChecklistGoal check = new ChecklistGoal(values[1], values[2], int.Parse(values[3]), int.Parse(values[4]), int.Parse(values[5]));
                _goals.Add(check);
                int timesCompleted = int.Parse(values[6]);
                int count = 0;

                while (count < timesCompleted)
                {
                    check.RecordEvent();
                    count++;
                }
            }
        }
    }

    public void SpendPoints()
    {
        Console.WriteLine($"You have {_score} points to spend");
        Console.WriteLine($"Your current level is {_level} your title is {_title}\n");

        Console.Write("Select an option: ");
        string suffixChoice = Console.ReadLine();


        //title suffix
        //unicorn
        //ninja
        //goal crusher
        //king
        //wizard
        //samurai
        //dragon
    }

    public void  CreatePrefixOptions()
    {
        string[] lines = System.IO.File.ReadAllLines("suffixOptions.txt");
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }

    public void CreateSuffixOptions()
    {
        
    }
}