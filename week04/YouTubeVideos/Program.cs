using System;
using System.Collections.Generic;

class Comment
{
    public string Author { get; set; }
    public string Text { get; set; }

    public Comment(string author, string text)
    {
        Author = author;
        Text = text;
    }

    public override string ToString()
    {
        return $"{Author}: {Text}";
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($"  - {comment}");
        }
        Console.WriteLine(new string('-', 40));
    }
}

class Program
{
    static void Main()
    {
        // Creating sample videos
        Video video1 = new Video("How to Code in C#", "John Doe", 600);
        Video video2 = new Video("Top 10 Programming Languages", "Jane Smith", 450);
        Video video3 = new Video("AI and the Future", "Alice Johnson", 720);

        // Adding comments
        video1.AddComment(new Comment("User1", "Great tutorial!"));
        video1.AddComment(new Comment("User2", "Very helpful, thanks!"));
        video1.AddComment(new Comment("User3", "I learned a lot!"));

        video2.AddComment(new Comment("User4", "Awesome list!"));
        video2.AddComment(new Comment("User5", "I love C#!"));
        video2.AddComment(new Comment("User6", "Go Rust!"));

        video3.AddComment(new Comment("User7", "AI is the future!"));
        video3.AddComment(new Comment("User8", "Scary and exciting at the same time."));
        video3.AddComment(new Comment("User9", "Nice insights!"));

        // Storing videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Displaying video information
        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}