
using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    private Random random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        char[] delimiters = new char[] { ' ', '\t',  '\r' };
        string[] wordsArray = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        List<string> wordsList = wordsArray.ToList();

        foreach(string wordInList in wordsList)
        {
            Word word = new Word(wordInList);
            _words.Add(word);
        }
        
    }
    
    public void ShowRandomWords(int numberToShow)
    {
        int hidden = 0;
        foreach (Word word in _words)
        {
            if (word.IsHidden() == true)
            {
                hidden++;
            }
        }

        int targetHides = Math.Min(numberToShow, hidden);
        int ShownSoFar = 0;

        while (ShownSoFar < targetHides)
        {
            int randNumb = random.Next(_words.Count());

            if(_words[randNumb].IsHidden() == false)
            {
                continue;
            }
            else
            {
                _words[randNumb].Show();
                ShownSoFar++;
            }
        }
    }
    public void HideRandomWords(int numberToHide)
    {   
        int notHidden = 0;
        foreach (Word word in _words)
        {
            if (word.IsHidden() == false)
            {
                notHidden++;
            }
        }

        int targetHides = Math.Min(numberToHide, notHidden);
        int hiddenSoFar = 0;

        while (hiddenSoFar < targetHides)
        {
            int randNumb = random.Next(_words.Count());

            if(_words[randNumb].IsHidden())
            {
                continue;
            }
            else
            {
                _words[randNumb].Hide();
                hiddenSoFar++;
            }
        }
    }

    public string GetDisplayText()
    {
        string formattedWords = "";
        foreach(Word word in _words)
        {
            formattedWords += word.GetDisplayText() + " ";
        }
        return $"{_reference.GetDisplayText()}: {formattedWords}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (word.IsHidden() == false)
            {
                return false;
            }
        }
    return true;
    }
   
}