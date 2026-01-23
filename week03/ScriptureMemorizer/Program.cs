using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Choose Difficulty: ");
        Console.WriteLine("1) Easy");
        Console.WriteLine("2) Medium");
        Console.WriteLine("3) Hard");
        string diffChoice = Console.ReadLine();
        int diff = 0;
        if (diffChoice == "1")
        {
            diff = 1;
        }
        else if (diffChoice == "2")
        {
            diff = 2;
        }
        else if (diffChoice == "3")
        {
            diff = 4;
        }
        
        Console.Clear();
        Console.WriteLine("Choose Scripture: ");
        Console.WriteLine("1) 1 John 4:10-11");
        Console.WriteLine("2) Moroni 10:32");
        Console.WriteLine("3) Proverbs 3:5-6");
        string scriptChoice = Console.ReadLine();

        Scripture scripture = null;
        
        if (scriptChoice == "1")
        {
            Reference reference = new Reference("1 John", 4, 10, 11);
            scripture = new Scripture(reference,"Herein is love, not that we loved God, but that He loved us, and sent His Son to be the\npropitiation for our sins. Beloved, if God so loved us, we ought also to love one another."); 
        }
        else if (scriptChoice == "2")
        {
            Reference reference = new Reference("Moroni", 10, 32);
            scripture = new Scripture(reference,"Yea, come unto Christ, and be perfected in him, and deny yourselves of all ungodliness;\nand if ye shall deny yourselves of all ungodliness, and love God with all your might, mind\nand strength, then is his grace sufficient for you, that by his grace ye may be perfect\nin Christ; and if by the grace of God ye are perfect in Christ, ye can in nowise deny the power of God.");
        }
        else if (scriptChoice == "3")
        {
            Reference reference = new Reference("Proverbs", 3, 5, 6);
            scripture = new Scripture(reference, "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all\nthy ways acknowledge him, and he shall direct thy paths.");
        }


        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden() == true)
            {
                break;
            }
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }
            else if (input == "")
            {
                scripture.HideRandomWords(diff);
            }
            else if (input.ToLower() == "u")
            {
                scripture.ShowRandomWords(diff);
            }
        }

        
    }
}