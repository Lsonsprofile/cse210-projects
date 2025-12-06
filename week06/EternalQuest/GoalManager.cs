using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    // These are the core data structures that maintain the application's state.
    // _goals: Stores all goal objects created by the user
    // _score: Tracks the user's total points earned
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public GoalManager()
    {
        // Fresh start every time!
    }

    // This is the central control method that runs the entire application.
    // It displays the menu and handles the user's choice in a continuous loop.
    public void Start()
    {
        string choice = "";

        // Main application loop - keeps running until user chooses to quit
        while (choice != "6")
        {
            DisplayPlayerInfo();
            ShowMenu();

            // Captures user's menu selection and routes to appropriate functionality
            choice = Console.ReadLine();
            Console.WriteLine();

            // Each menu option triggers a specific method that performs a discrete task
            if (choice == "1")      CreateGoal();      // Add new goal
            else if (choice == "2") ListGoalDetails(); // Display all goals
            else if (choice == "3") SaveGoals();       // Persist data to file
            else if (choice == "4") LoadGoals();       // Retrieve data from file
            else if (choice == "5") RecordEvent();     // Mark goal as completed
            else if (choice == "6")                    // Exit application
            {
                Console.WriteLine("Thanks for playing! See you on the quest tomorrow! 🌟");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
            }

            Console.WriteLine();  // blank line for readability between operations
        }
    }

    // Shows current score - simple output method
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points\n");
    }

    // Presents the navigation options to the user
    // This is the "control panel" of the application
    private void ShowMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Create New Goal");    // Data creation
        Console.WriteLine("  2. List Goals");         // Data viewing
        Console.WriteLine("  3. Save Goals");         // Data persistence
        Console.WriteLine("  4. Load Goals");         // Data retrieval
        Console.WriteLine("  5. Record Event");       // Data modification
        Console.WriteLine("  6. Quit");               // Application termination
        Console.Write("Select a choice from the menu: ");
    }

    // This is a complex method that handles the creation of all three goal types
    // It guides the user through a series of steps to define a new goal
    public void CreateGoal()
    {
        // First, let user choose what type of goal they want to create
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");    // One-time completion
        Console.WriteLine("  2. Eternal Goal");   // Repeatable forever
        Console.WriteLine("  3. Checklist Goal"); // Multiple completions with bonus
        Console.Write("Which type of goal would you like to create? ");

        string typeChoice = Console.ReadLine();
        
        // Ensure the user selected a valid goal type
        if (typeChoice != "1" && typeChoice != "2" && typeChoice != "3")
        {
            Console.WriteLine("Invalid goal type. Please enter 1, 2, or 3.\n");
            return;  // Exit early on invalid input
        }
        
        Console.WriteLine();

        // All goals share these basic attributes
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Goal name cannot be empty.\n");
            return;  // Exit if required field is empty
        }

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Goal description cannot be empty.\n");
            return;
        }

        // Points determine how much this goal is worth when completed
        int points = 0;
        Console.Write("What is the amount of points associated with this goal? ");
        if (!int.TryParse(Console.ReadLine(), out points) || points < 0)
        {
            Console.WriteLine("Invalid points value. Please enter a positive number.\n");
            return;  // Exit if points value is invalid
        }

        Goal newGoal = null;  // Will hold the created goal object

        // Based on user's choice, create the appropriate goal type
        
        if (typeChoice == "1")  // Simple Goal (one-time)
        {
            newGoal = new SimpleGoal(name, description, points);
            Console.WriteLine("Simple Goal created! 🎯");
        }
        else if (typeChoice == "2")  // Eternal Goal (repeatable)
        {
            newGoal = new EternalGoal(name, description, points);
            Console.WriteLine("Eternal Goal created! ∞");
        }
        else if (typeChoice == "3")  // Checklist Goal (multi-step)
        {
            // Checklist goals need extra information: target count and bonus
            int target = 0;
            int bonus = 0;
            
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            if (!int.TryParse(Console.ReadLine(), out target) || target <= 0)
            {
                Console.WriteLine("Invalid target value. Please enter a positive number greater than 0.\n");
                return;
            }

            Console.Write("What is the bonus for accomplishing it that many times? ");
            if (!int.TryParse(Console.ReadLine(), out bonus) || bonus < 0)
            {
                Console.WriteLine("Invalid bonus value. Please enter a positive number.\n");
                return;
            }

            newGoal = new ChecklistGoal(name, description, points, target, bonus);
            Console.WriteLine("Checklist Goal created! 🏆");
        }

        // Add the newly created goal to the collection
        _goals.Add(newGoal);
        Console.WriteLine("Goal added successfully!\n");
    }

    // Displays all goals with their current status
    public void ListGoalDetails()
    {
        // Check if there are any goals to display
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.\n");
            return;  // Early exit for empty collection
        }

        // Loop through all goals and show their details
        Console.WriteLine("Your goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            // Each goal knows how to format its own details
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine();
    }

    // Records completion of a goal and updates points
    public void RecordEvent()
    {
        // Ensure there are goals before attempting to record an event
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available to record events for.\n");
            return;
        }
        
        // Show goals so user can choose which one they completed
        ListGoalDetails();
        
        Console.Write("Which goal did you accomplish? ");
        int index = 0;
        
        // Parse and validate the user's selection
        if (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > _goals.Count)
        {
            Console.WriteLine($"Invalid selection. Please enter a number between 1 and {_goals.Count}.\n");
            return;  // Exit on invalid input
        }
        
        index--; // Convert to 0-based index for array access

        // Perform the actual recording of the event
        if (index >= 0 && index < _goals.Count)
        {
            // Each goal type handles its own completion logic
            int pointsEarned = _goals[index].RecordEvent();
            
            AddPoints(pointsEarned);
        }
        Console.WriteLine();
    }

    // Saves all goals and score to a file
    public void SaveGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to save. Please create goals first.\n");
            return;  // Don't attempt to save empty data
        }
        
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.\n");
            return;  // Exit if no filename provided
        }

        try
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                file.WriteLine(_score);  // Save score first
                
                // Each goal type knows how to serialize itself
                foreach (Goal goal in _goals)
                {
                    file.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}\n");
        }
    }

    // Loads goals and score from a file
    public void LoadGoals()
    {
        Console.Write("What is the filename to load? ");
        string filename = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.\n");
            return;
        }

        try
        {
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                
                if (lines.Length == 0)
                {
                    Console.WriteLine("File is empty.\n");
                    return;
                }
                
                if (!int.TryParse(lines[0], out _score))
                {
                    Console.WriteLine("Invalid score format in file.\n");
                    return;
                }
                
                _goals.Clear();  // Clear existing goals before loading

                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (string.IsNullOrWhiteSpace(line)) continue;  // Skip empty lines
                    
                    string[] parts = line.Split(':');
                    if (parts.Length < 2)
                    {
                        Console.WriteLine($"Invalid format in line {i + 1}. Skipping...");
                        continue;  // Skip malformed lines
                    }
                    
                    string type = parts[0];
                    string[] data = parts[1].Split(',');

                    // Based on the type, recreate the appropriate goal object
                    try
                    {
                        if (type == "SimpleGoal")
                        {
                            if (data.Length >= 4)
                            {
                                _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                            }
                        }
                        else if (type == "EternalGoal")
                        {
                            if (data.Length >= 3)
                            {
                                _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2]), false));
                            }
                        }
                        else if (type == "ChecklistGoal")
                        {
                            if (data.Length >= 6)
                            {
                                _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]), 
                                    int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])));
                            }
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Invalid data format in line {i + 1}. Skipping...");
                    }
                }
                Console.WriteLine($"Goals loaded successfully! Loaded {_goals.Count} goals.\n");
            }
            else
            {
                Console.WriteLine("File not found.\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}\n");
        }
    }

    // These are utility methods that support the main functionality
    
    // Updates and displays the user's score
    public void AddPoints(int points)
    {
        _score += points;
        
        Console.WriteLine($"Congratulations! You earned {points} points! 🎉");
        Console.WriteLine($"You now have {_score} points.\n");
    }

    // Provides controlled access to the goals list
    public List<Goal> GetGoals() => _goals;
}