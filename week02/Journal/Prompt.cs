using System;

public class Prompt
{
    Random random = new Random();
    int randomNumber;

    public void GetPrompt()
    {
        randomNumber = random.Next(1, 6);
        
        if (randomNumber == 1)
        {
            Console.WriteLine("What was the best part of your day?");
        }
        else if (randomNumber == 2)
        {
            Console.WriteLine("What one thing would you change about today?");
        }
        else if (randomNumber == 3)
        {
            Console.WriteLine("What is something you are looking forward to?");
        }
        else if (randomNumber == 4)
        {
            Console.WriteLine("Did you have a chance to share the gospel today?");
        }
        else if (randomNumber == 5)
        {
            Console.WriteLine("What was the strangest thing that happened today?");
        }
    }
}