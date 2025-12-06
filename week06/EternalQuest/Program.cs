/*
CREATIVITY & EXCEEDING REQUIREMENTS:
- Eternal goals show "∞" symbol and a special message every time
- Checklist goals show live progress and big bonus celebration
- Full error handling on invalid menu choices and file loading for every input type
- Clean, professional code structure that’s easy to extend with new goal types
*/
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}