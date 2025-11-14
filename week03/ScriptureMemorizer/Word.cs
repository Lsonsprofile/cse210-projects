using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    // Constructor: initializes the word with its text and sets it as visible
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Hides the word by marking it as hidden
    public void Hide()
    {
        _isHidden = true;
    }

    // Shows the word by marking it as visible
    public void Show()
    {
        _isHidden = false;
    }

    // Returns whether the word is currently hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Returns the display version of the word:
    // - If hidden, shows underscores
    // - If visible, shows the actual word
    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;// if the word is hidden, it will show underscores, if the word is visible, it will show the actual word
    }
}
