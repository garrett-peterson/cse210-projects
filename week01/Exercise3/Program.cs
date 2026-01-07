using System;

class Program
{
    static void Main(string[] args)
    {
        string again = "no";
        do 
        {
            Random randomGenerator = new Random();
            int randomNumber = randomGenerator.Next(1, 100);

            Console.WriteLine("Try and guess the magic number!");
            
            int tries = 0;
            string running = "yes";
            

            while (running == "yes")
            {
            
                Console.Write("What is your guess? ");
                string answer = Console.ReadLine();
                int guess = int.Parse(answer);
                
                if (guess == randomNumber)
                {
                    tries ++;
                    running = "no";
                    if (tries == 1)
                    {
                        Console.WriteLine($"Correct! You guessed {tries} time.");
                    }
                    else
                    {
                        Console.WriteLine($"Correct! You guessed {tries} times.");
                    }
                    
                    Console.Write("Would you like to play again (y/n): ");
                    string reply  = Console.ReadLine();

                    if (reply == "y")
                    {
                        again = "yes";
                    }
                    else
                    {
                        again = "no";
                    }
                }
                else if (guess > randomNumber)
                {
                    Console.WriteLine("Lower");
                    tries ++;
                }
                else if (guess < randomNumber)
                {
                    Console.WriteLine("Higher");
                    tries ++;  
                }

            }
        } while (again == "yes");
    }
}