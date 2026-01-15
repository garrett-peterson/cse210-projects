using System.IO; 
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {

        foreach (Entry E in _entries)
        {
            E.Display();
        }
    }

    public void SaveToFile(string file)
    {
        string folderPath = @"C:\Users\garrett.peterson\Desktop\School\Term 2\CSE210\cse210-projects\week02\Journal";
        string fullPath = Path.Combine(folderPath, file);
        using (StreamWriter outputFile = new StreamWriter(fullPath))
        {
            foreach (Entry E in _entries)
            {
                outputFile.WriteLine(E._date);
                outputFile.WriteLine(E._promptText);
                outputFile.WriteLine(E._entryText);
            }
        }
    }

    public void LoadFromFile(string file)
    {   
        string folderPath = @"C:\Users\garrett.peterson\Desktop\School\Term 2\CSE210\cse210-projects\week02\Journal";
        string fullPath = Path.Combine(folderPath, file);
        string[] lines = System.IO.File.ReadAllLines(fullPath);

        for (int i = 0; i < lines.Length; i +=3)
        {
            string date = lines[i];
            string prompt = lines[i+1];
            string text = lines[i+2];

            Entry entry = new Entry();
            entry._date = date;
            entry._promptText = prompt;
            entry._entryText = text;

            AddEntry(entry);
        }
        
    }
}