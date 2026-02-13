public class Title
{
    private string _title;
    private int _cost;
    private int _level;

    public Title (string title, int cost, int level)
    {
        _title = title;
        _cost = cost;
        _level = level;
    }

    public bool CanAfford(int score)
    {
        return (score >= _cost);
    }

    public bool MeetsLevelRequirement(int level)
    {
        return (level >= _level);
    }

    public void DisplayTitle()
    {
        Console.WriteLine($"{_title}   Cost:{_cost}   Required Level:{_level}");
    }
}