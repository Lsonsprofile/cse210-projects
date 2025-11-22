using System;

public class Video
{
    private string _title;
    private string _author;
    private int _LenghtInSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lenghtInSeconds)
    {
        _title = title;
        _author = author;
        _LenghtInSeconds = lenghtInSeconds;
        _comments = new List<Comment>();
    }

    // METHOD AddComment(a Comment object)
    public void AddComment(Comment writtenComment)
    {
        _comments.Add(writtenComment);
    }
    // METHOD GetNumberOfComments()
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // METHOD DisplayVideoInfo()
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"{_title} by {_author} ({_LenghtInSeconds} seconds)");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");

        foreach (Comment writtenComment in _comments)
        {
            Console.WriteLine($"  {writtenComment.GetDisplayText()}");
        }
        Console.WriteLine();
    }
}