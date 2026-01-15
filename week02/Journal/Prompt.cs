using System;

public class Prompt
{
    public List<string> _prompts = new List<string>();
    
    int nextPrompt = 0;
    bool shuffled = false;
    List<string> shuffledPrompts;
    public string GetRandomPrompt()
    {
        if (_prompts.Count() == 0)
        {
            string folderPath = @"C:\Users\garrett.peterson\Desktop\School\Term 2\CSE210\cse210-projects\week02\Journal";
            string fullPath = Path.Combine(folderPath, "prompts.txt");
            string[] lines = System.IO.File.ReadAllLines(fullPath);

            foreach (string line in lines)
            {
                _prompts.Add(line);
            }
        }

        if (shuffled == false)
        {
            shuffledPrompts = new List<string>(_prompts.Shuffle());
            shuffled = true;
        }

        string promptText = shuffledPrompts[nextPrompt];

        if (nextPrompt >= shuffledPrompts.Count() - 1)
        {
            nextPrompt = 0;
            shuffled = false;
        }
        else
        {
            nextPrompt++;
        }

        return promptText;
    }

    public void AddPrompt (string newPrompt)
    {
        if (_prompts.Count() == 0)
        {
            string folderPath1 = @"C:\Users\garrett.peterson\Desktop\School\Term 2\CSE210\cse210-projects\week02\Journal";
            string fullPath1 = Path.Combine(folderPath1, "prompts.txt");
            string[] lines = System.IO.File.ReadAllLines(fullPath1);

            foreach (string line in lines)
            {
                _prompts.Add(line);
            }
        }

        _prompts.Add(newPrompt);

        string folderPath = @"C:\Users\garrett.peterson\Desktop\School\Term 2\CSE210\cse210-projects\week02\Journal";
        string fullPath = Path.Combine(folderPath, "prompts.txt");
        using (StreamWriter outputFile = new StreamWriter(fullPath))
        {
     
            for (int i = 0; i < _prompts.Count; i++)
            {
                outputFile.WriteLine(_prompts[i]);
            }
        }
        shuffled = false;
    }
    
}