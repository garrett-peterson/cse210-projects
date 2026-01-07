using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of number, type 0 when finished.");
        int notZero = 1;
        List <int> numbers = new List<int>();


        while (notZero != 0)
        {
            Console.Write("Enter number: ");
            string answer = Console.ReadLine();
            int numb = int.Parse(answer);

            if (numb == 0)
            {
                notZero = 0;
                int sum = numbers.Sum();
                double avg = numbers.Average();
                int large = numbers.Max();
                int small = numbers.Where(n => n > 0).Min();

                Console.WriteLine($"The sum is: {sum}");
                Console.WriteLine($"The average is: {avg}");
                Console.WriteLine($"The largest number is: {large}");
                Console.WriteLine($"The smallest positive number is: {small}");

            }

            else
            {
                numbers.Add(numb);
            }
            
        }
    }
}