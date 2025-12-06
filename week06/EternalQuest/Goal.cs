using System;

public abstract class Goal
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

    // These MUST be implemented differently by each child
    public abstract int RecordEvent();
    public abstract bool IsComplete();

    // This works perfectly for Simple & Eternal — only Checklist will override
    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    // Each child saves itself differently to file
    public abstract string GetStringRepresentation();
}