// I added an Undo Feature to my programme. I used a Stack to keep track of the changes made to the scripture. 
//I also added a method to undo the last change made to the scripture.
using System;

public class Scripture
{
    private Reference _reference; // Reference object that holds the book, chapter, and verse
    private Word[] _words; // Array of words that holds the words in the scripture
    private Stack<int[]> _undoHistory = new Stack<int[]>(); // Stack to track hidden word indexes for undo

    public Scripture(Reference reference, string fullText)
    {
        _reference = reference;
        string[] wordsArray = fullText.Split(' '); // Splits the full text into an array of words
        _words = new Word[wordsArray.Length]; // Creates an array of Word objects

        for (int i = 0; i < wordsArray.Length; i++) // Loops through the array of words
        {
            string trimWord = wordsArray[i].Trim(); // Trims the word of any whitespace
            if (trimWord != "") // If the word is not empty
            {
                _words[i] = new Word(trimWord); // Creates a new Word object and adds it to the array
            }
        }
    }

    // Hides random words and tracks which ones were hidden
    public int[] HideRandomWordsWithTracking(int howMany = 2)
    {
        List<int> hiddenThisTime = new List<int>();
        Random rand = new Random();

        int visibleCount = 0;
        for (int i = 0; i < _words.Length; i++)
            if (_words[i] != null && !_words[i].IsHidden()) visibleCount++;

        if (visibleCount == 0) return new int[0];
        if (howMany > visibleCount) howMany = visibleCount;

        int done = 0;
        while (done < howMany)
        {
            int i = rand.Next(_words.Length);
            if (_words[i] != null && !_words[i].IsHidden())
            {
                _words[i].Hide(); // Hide the word
                hiddenThisTime.Add(i); // Track the index
                done++;
            }
        }

        _undoHistory.Push(hiddenThisTime.ToArray()); // Save this set for undo
        return hiddenThisTime.ToArray(); // Return the indexes hidden this time
    }

    // Undo the last hide operation
    public void UndoLastHide()
    {
        if (_undoHistory.Count > 0) // If there is something to undo
        {
            int[] lastHidden = _undoHistory.Pop(); // Get the last set of hidden indexes
            foreach (int index in lastHidden)
            {
                if (_words[index] != null)
                {
                    _words[index].Show(); // Unhide the word
                }
            }
        }
    }

    // Returns the array of Word objects
    public Word[] GetWords()
    {
        return _words;
    }

    // Builds and returns the full display text with hidden words replaced by underscores
    public string GetDisplayText()
    {
        string result = ""; // Empty string to build the result

        for (int i = 0; i < _words.Length; i++) // Loop through every word
        {
            if (_words[i] != null) // If the word exists
            {
                result += _words[i].GetDisplayText() + " "; // Add the word + space
            }
        }

        result = result.Trim(); // Remove any trailing spaces
        return _reference.GetDisplayText() + "\n" + result; // Add the reference + verse text in another line
    }

    // Checks if all words are hidden
    public bool IsCompletelyHidden()
    {
        for (int i = 0; i < _words.Length; i++) // Loop through every word in the array
        {
            if (_words[i] != null && !_words[i].IsHidden()) // check if any word is still visible
            {
                return false; // if not completely hidden
            }
        }
        return true; // if all words are hidden
    }
}
