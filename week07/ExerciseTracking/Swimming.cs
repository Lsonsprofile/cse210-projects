using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int lengthInMinutes, int laps)
        : base(date, lengthInMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // 50 meters per lap → convert to miles (1609.344 meters = 1 mile)
        return Math.Round(_laps * 50 / 1609.344, 1); // This calculates the distance in miles
    }

    public override double GetSpeed() // This overrides the base class method showing polymorphism
        => Math.Round(GetDistance() / (LengthInMinutes / 60.0), 1);

    public override double GetPace() 
        => Math.Round(LengthInMinutes / GetDistance(), 2);
}