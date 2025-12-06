using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points)
    {
        _isComplete = false;  // starts incomplete
    }

    // This constructor is for loading from file (we'll use later)
    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return _points;  // return the points earned this time
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        // Format: SimpleGoal:Run a marathon,Complete a full marathon,1000,True
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
}