using System.ComponentModel;

public class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public virtual void RecordEvent()
    {
    }

    public virtual bool IsComplete()
    {
        return false;
    }

    public virtual string GetDetailsString()
    {
        string checkbox = "[ ]";

        if (IsComplete())
        {
            checkbox = "[X]";
        }

        return $"{checkbox} {_shortName} ({_description})";
    }

    public virtual string GetStringRepresentation()
    {
        return "";
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public virtual int ReturnScore(bool wasComplete)
    {
        if (wasComplete)
        {
            return 0;
        }
        return _points;
    }

}