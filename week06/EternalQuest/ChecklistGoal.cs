public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) 
        : base (name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override void RecordEvent()
    {   
        if (_amountCompleted < _target)
        {
            _amountCompleted += 1;
        }
        
    }

    public override bool IsComplete()
    {
        if(_amountCompleted >= _target)
        {
            return true;
        }

        return false;
    }

    public override string GetDetailsString()
    {
        string checkbox ="[ ]";

        if (_amountCompleted >= _target)
        {
             if (IsComplete())
            {
                checkbox = "[X]";
            }
        }

        return $"{checkbox} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal,{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
    }

    public override int ReturnScore(bool wasComplete)
    {
        if(wasComplete)
        {
            return 0;
        } 
        if (IsComplete())
        {
            return _points + _bonus;
        }
        return _points;
    }
}