using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        // Nothing extra to store — it never finishes!
    }

    // For loading from file
    public EternalGoal(string name, string description, int points, bool dummy)
        : base(name, description, points)
    {
        // We ignore the dummy parameter — Eternal goals are never complete
    }

    public override int RecordEvent()
    {
        // Every single time you record it → you get points!
        Console.WriteLine($"Recorded \"{_shortName}\" — you earn {_points} points every time! ∞");
        return _points;
    }

    public override bool IsComplete()
    {
        // Eternal goals are NEVER complete → that’s the whole point!
        return false;
    }

    // We use the base version — no extra text needed
    // So we don't override GetDetailsString()

    public override string GetStringRepresentation()
    {
        // Format: EternalGoal:Read Scriptures,Read every day,100
        // Note: no "True/False" because it's never done
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}