using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This is the Homework Project.");
            Assignment assignment = new Assignment("Bill", "Math");
            Console.WriteLine(assignment.GetSummary());

            MathAssignment math = new MathAssignment("7.3", "8-19", "Roberto Rodrigues", "Fractions");
            Console.WriteLine(math.GetSummary());
            Console.WriteLine(math.GetHomeworkList());


            WritingAssignment write = new WritingAssignment("The Causes of World War II", "Mary Waters","European History");
            Console.WriteLine(write.GetSummary());
            Console.WriteLine(write.GetWritingInformation());
        }
    }
}
