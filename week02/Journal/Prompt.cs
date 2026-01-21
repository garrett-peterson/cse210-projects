using System;
using System.IO;
using System.Collections.Generic;
public class Prompt
{
    private string _promptsFile = "prompts.txt";
    public List<string> _prompts = new List<string>();
    
    int nextPrompt = 0;
    bool shuffled = false;
    List<string> shuffledPrompts;
    public string GetRandomPrompt()
    {
        if (_prompts.Count() == 0)
        {

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), _promptsFile);

            string[] lines = System.IO.File.ReadAllLines(_promptsFile);

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
            string[] lines = System.IO.File.ReadAllLines(_promptsFile);

            foreach (string line in lines)
            {
                _prompts.Add(line);
            }
        }

        _prompts.Add(newPrompt);

        using (StreamWriter outputFile = new StreamWriter(_promptsFile))
        {
     
            for (int i = 0; i < _prompts.Count; i++)
            {
                outputFile.WriteLine(_prompts[i]);
            }
        }
        shuffled = false;
    }
    
}