// Journal.cs - Core class for managing journal entries
// Handles storage, prompt generation, display, and file operations with robust input validation
// CREATIVITY & EXCEEDING REQUIREMENTS:
// 1. Input validation loops — user can't proceed with invalid/missing files or inputs
// 2. Dual-format save: .txt (original) + .csv (Excel-ready with proper escaping)
// 3. Auto CSV detection on load with header skipping
// 4. Graceful error handling with specific messages
// 5. Display file path on load and save

using System;

public class Journal
{
    // Stores all journal entries in memory
    public List<Entry> _entries = new List<Entry>();
    
    // Provides random writing prompts to inspire users
    public PromptGenerator _promptGenerator = new PromptGenerator();

    // Adds a new entry by:
    // 1. Selecting a random prompt
    // 2. Capturing user response
    // 3. Recording current date automatically
    // 4. Creating and storing a new Entry object
    public void AddEntry()
    {
        string prompt = _promptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Entry newEntry = new Entry();
        newEntry._date = DateTime.Now.ToShortDateString();
        newEntry._promptText = prompt;
        newEntry._entryText = response;

        _entries.Add(newEntry);
    }

    // Displays all entries in chronological order
    // Shows friendly message when journal is empty
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Saves journal to file with input validation loop
    // Continues prompting until a valid, writable path is provided
    // Saves in BOTH .txt (original format) and .csv (Excel-ready)
    // Uses ~|~ for .txt to avoid text conflicts
    // Now shows FULL PATH so you can find the file easily
    public void SaveToFile(string filename)
    {
        string fileToSave = filename.Trim();

        // If no extension, default to .csv (user wants Excel file)
        if (!Path.HasExtension(fileToSave))
            fileToSave += ".csv";

        string csvFile = Path.ChangeExtension(fileToSave, ".csv");
        string txtFile = Path.ChangeExtension(fileToSave, ".txt");

        while (true)
        {
            if (string.IsNullOrWhiteSpace(fileToSave))
            {
                Console.Write("Filename cannot be empty. Enter a valid filename to save: ");
                fileToSave = Console.ReadLine().Trim();
                if (!Path.HasExtension(fileToSave)) fileToSave += ".csv";
                csvFile = Path.ChangeExtension(fileToSave, ".csv");
                txtFile = Path.ChangeExtension(fileToSave, ".txt");
                continue;
            }

            try
            {
                // Save CSV first (this is the main Excel file)
                using (StreamWriter csv = new StreamWriter(csvFile))
                {
                    csv.WriteLine("Date,Prompt,Response");
                    foreach (Entry entry in _entries)
                    {
                        string safePrompt = $"\"{entry._promptText.Replace("\"", "\"\"")}\"";
                        string safeResponse = $"\"{entry._entryText.Replace("\"", "\"\"")}\"";
                        csv.WriteLine($"{entry._date},{safePrompt},{safeResponse}");
                    }
                }

                // Save .txt as backup
                using (StreamWriter txt = new StreamWriter(txtFile))
                {
                    foreach (Entry entry in _entries)
                    {
                        txt.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}");
                    }
                }

                // Show FULL PATH so you know exactly where files are saved
                string fullCsvPath = Path.GetFullPath(csvFile);
                string fullTxtPath = Path.GetFullPath(txtFile);

                Console.WriteLine($"Saved successfully!");
                Console.WriteLine($"   Excel CSV: {fullCsvPath}");
                Console.WriteLine($"   Backup TXT: {fullTxtPath}\n");
                break;
            }
            catch (UnauthorizedAccessException)
            {
                Console.Write($"Access denied to '{fileToSave}'. Enter different filename: ");
                fileToSave = Console.ReadLine().Trim();
                if (!Path.HasExtension(fileToSave)) fileToSave += ".csv";
                csvFile = Path.ChangeExtension(fileToSave, ".csv");
                txtFile = Path.ChangeExtension(fileToSave, ".txt");
            }
            catch (DirectoryNotFoundException)
            {
                Console.Write($"Folder not found for '{fileToSave}'. Enter valid path: ");
                fileToSave = Console.ReadLine().Trim();
                if (!Path.HasExtension(fileToSave)) fileToSave += ".csv";
                csvFile = Path.ChangeExtension(fileToSave, ".csv");
                txtFile = Path.ChangeExtension(fileToSave, ".txt");
            }
            catch (Exception ex)
            {
                Console.Write($"Error: {ex.Message}. Try again: ");
                fileToSave = Console.ReadLine().Trim();
                if (!Path.HasExtension(fileToSave)) fileToSave += ".csv";
                csvFile = Path.ChangeExtension(fileToSave, ".csv");
                txtFile = Path.ChangeExtension(fileToSave, ".txt");
            }
        }
    }

    // Loads journal from file with persistent validation
    // Loops until user provides an existing, readable file
    // Supports both .txt and .csv formats automatically
    // Skips CSV header and malformed lines
    public void LoadFromFile(string filename)
    {
        string fileToLoad = filename.Trim();

        while (true)
        {
            if (string.IsNullOrWhiteSpace(fileToLoad))
            {
                Console.Write("Filename cannot be empty. Enter filename to load: ");
                fileToLoad = Console.ReadLine().Trim();
                continue;
            }

            try
            {
                if (!File.Exists(fileToLoad))
                {
                    Console.Write($"File '{fileToLoad}' not found. Enter correct filename: ");
                    fileToLoad = Console.ReadLine().Trim();
                    continue;
                }

                _entries.Clear();
                string[] lines = File.ReadAllLines(fileToLoad);
                bool isCsv = fileToLoad.EndsWith(".csv", StringComparison.OrdinalIgnoreCase);

                // Skip CSV header if present
                int startIndex = isCsv && lines.Length > 0 && lines[0].StartsWith("Date,Prompt") ? 1 : 0;

                for (int i = startIndex; i < lines.Length; i++)
                {
                    string line = lines[i];
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // Dynamic split based on file type
                    string[] parts = isCsv ? line.Split(',') : line.Split("~|~");
                    if (parts.Length < 3) continue;

                    Entry loadedEntry = new Entry();
                    loadedEntry._date = isCsv ? parts[0] : parts[0];
                    loadedEntry._promptText = isCsv ? parts[1].Trim('"').Replace("\"\"", "\"") : parts[1];
                    loadedEntry._entryText = isCsv ? parts[2].Trim('"').Replace("\"\"", "\"") : parts[2];

                    _entries.Add(loadedEntry);
                }

                Console.WriteLine($"Journal loaded from {fileToLoad}\n");
                break;
            }
            catch (Exception)
            {
                Console.Write($"Error reading '{fileToLoad}'. Enter valid filename: ");
                fileToLoad = Console.ReadLine().Trim();
            }
        }
    }
}