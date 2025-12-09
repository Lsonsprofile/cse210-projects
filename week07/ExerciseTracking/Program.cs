using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var activities = new List<Activity>
        {
            new Running("03 Nov 2022", 30, 3.0),        // Exact example from assignment
            new Cycling("03 Nov 2022", 30, 6.0),        // 6 mph × 0.5 hr = 3.0 miles
            new Swimming("03 Nov 2022", 30, 48)         // 48 laps × 50m = 2400m ≈ 1.5 miles
        };

        Console.WriteLine("Exercise Tracking Program\n");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

       
    }
}