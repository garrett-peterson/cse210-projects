using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
       static void DisplayMessage()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            string answer = Console.ReadLine();
            int numb = int.Parse(answer);
            return numb;
        }

        static int SquareNumber(int number)
        {
            int squaredNumb = number * number;
            return squaredNumb;
        }

        static void DisplayResult()
        {
            DisplayMessage();
            string name = PromptUserName();
            int favNumb = PromptUserNumber();
            int square = SquareNumber(favNumb);

            Console.WriteLine($"{name}, the square of your number is {square}");
        }

        DisplayResult();
        
    }
}