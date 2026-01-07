using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {

        Console.Write("Enter your grade: ");
        string grade = Console.ReadLine();

        int gradeNumber = int.Parse(grade);

        string letter = "Blank";

        if (gradeNumber >= 90)
        {
            letter = "A";
        }
        else if (gradeNumber >= 80)
        {
            letter = "B";
        }
        else if (gradeNumber >= 70)
        {
            letter = "C";
        }
        else if (gradeNumber >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"Your letter grade is {letter}");

        if (gradeNumber >= 70)
        {
            Console.WriteLine("Congratulations! You passed your course!");
        }
        else
        {
            Console.WriteLine("You did not pass your course. Better look next time!");
        }
       
    }
}