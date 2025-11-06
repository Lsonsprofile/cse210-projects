using System;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>();

    public PromptGenerator()
    {
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
        _prompts.Add("What am I grateful for today?");  
        _prompts.Add("What made me smile today?");
        _prompts.Add("What is one thing I learned about myself today?");
        _prompts.Add("Who am I thankful for and why?");
        _prompts.Add("What small win did I have today?");
        _prompts.Add("What challenged me today, and how did I handle it?");
        _prompts.Add("What is one act of kindness I gave or received?");
        _prompts.Add("What moment today felt peaceful?");
        _prompts.Add("What am I looking forward to tomorrow?");
        _prompts.Add("What song or sound defined my day?");
        _prompts.Add("If today were a movie title, what would it be?");
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}