using System;

class Program
{
    static void Main(string[] args)
    {
        // create a video list
        List<Video> videos = new List<Video>();

        // add some videos to the list
        //make video one
        Video video1 = new Video("Learn C# in 10 Minutes", "Brother Birch", 600);
        video1.AddComment(new Comment("Sarah", "This saved my grade!"));
        video1.AddComment(new Comment("Mike", "Finally understand classes!"));
        video1.AddComment(new Comment("Emma", "Best explanation ever"));
        video1.AddComment(new Comment("Josh", "Can you do one for loops?"));
        videos.Add(video1);

        //make video two
        Video video2 = new Video("How to Make Pizza", "Chef John", 480);
        video2.AddComment(new Comment("Lily", "My pizza turned out perfect!"));
        video2.AddComment(new Comment("Alex", "The dough tip is genius"));
        video2.AddComment(new Comment("Tom", "10/10 would eat again"));
        videos.Add(video2);

        // make video three
        Video video3 = new Video("Funny Cat Compilation 2025", "CatLover99", 185);
        video3.AddComment(new Comment("Grace", "The orange cat at 0:45"));
        video3.AddComment(new Comment("Noah", "I laughed so hard I cried"));
        video3.AddComment(new Comment("Zoe", "My cat does the same thing!"));
        video3.AddComment(new Comment("Liam", "Need part 2 please!"));
        videos.Add(video3);

        // make video four
        Video video4 = new Video("How to Code in Python", "CodeMaster", 720);
        video4.AddComment(new Comment("Ava", "I'm learning Python now!"));
        video4.AddComment(new Comment("Leo", "This is so helpful"));
        video4.AddComment(new Comment("Sophia", "Can you do a tutorial on C#?"));
        videos.Add(video4);

        Console.WriteLine("Welcome to YouTube!");

        // display all videos
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}