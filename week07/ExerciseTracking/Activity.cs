using System;

/// <summary>
/// Base class for all fitness activities. Uses inheritance and polymorphism.
/// </summary>
public class Activity
{
    private string _date;
    private int _lengthInMinutes;

    // Full property syntax instead of expression-bodied
    protected int LengthInMinutes
    {
        get { return _lengthInMinutes; }
    }

    public Activity(string date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    // Expanded methods instead of => shorthand
    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        DateTime date = DateTime.Parse(_date);
        string formattedDate = date.ToString("dd MMM yyyy");
        string activityType = this.GetType().Name;

        double distance = Math.Round(GetDistance(), 1);
        double speed = Math.Round(GetSpeed(), 1);
        double pace = Math.Round(GetPace(), 2);

        return $"{formattedDate} {activityType} ({LengthInMinutes} min)- " +
               $"Distance {distance} miles, Speed {speed} mph, Pace: {pace} min per mile";
    }
}
