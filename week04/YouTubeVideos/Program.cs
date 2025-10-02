using System;

class Program
{
    static void Main(string[] args)
    {
    Console.WriteLine("Program started...");

        Video v1 = new Video("Learning C#", "Clarke David", 600);
        Video v2 = new Video("Funny Cats Compilation", "BestCatMoments", 300);
        Video v3 = new Video("Travel Vlog: Paris", "Wanderlust", 900);

        
        v1.AddComment(new Comment("Benny", "Great explanation,very inmpactful!"));
        v1.AddComment(new Comment("Bob", "Very helpful, thanks."));
        v1.AddComment(new Comment("Queen", "Please do more tutorials."));

        v2.AddComment(new Comment("Diana", "Awwwn, So cute!"));
        v2.AddComment(new Comment("Jack", "Made my day."));
        v2.AddComment(new Comment("Princess", "I love cats so much!"));

        v3.AddComment(new Comment("Faith", "Paris looks amazing."));
        v3.AddComment(new Comment("Hannah", "I want to go there someday."));
        v3.AddComment(new Comment("Ian", "Beautiful shots!"));

    
        List<Video> videos = new List<Video> { v1, v2, v3 };

        
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            foreach (Comment c in video.GetComments())
            {
                Console.WriteLine($" - {c.GetCommenter()}: {c.GetText()}");
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}