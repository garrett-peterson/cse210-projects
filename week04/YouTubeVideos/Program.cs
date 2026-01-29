using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video song = new Video("Catchy Song", "Singer", 174);
        song.AddComment("Billy", "I love this song!");
        song.AddComment("James", "Its so catchy");
        song.AddComment("Sally", "My brother shared this with me and I love it!");
        song.AddComment("Jeff", "My name is Jeff");

        Video howTo = new Video("How to fix a car", "Frank", 500);
        howTo.AddComment("Jill", "This helped so much!");
        howTo.AddComment("Jeff", "My name is Jeff");
        howTo.AddComment("John", "Finally got it fixed, thank you!");
        howTo.AddComment("Grant", "Great video!");
        
        Video movieTrailer = new Video("Movie Trailer", "Movie studio", 120);
        movieTrailer.AddComment("Mark", "First!");
        movieTrailer.AddComment("Jeff", "My name is Jeff");
        movieTrailer.AddComment("Janice", "I can't wait for this movie!");
        movieTrailer.AddComment("Chris", "I love these actors");

        videos.Add(song);
        videos.Add(howTo);
        videos.Add(movieTrailer);

        foreach (Video video in videos)
        {
            Console.WriteLine(video.DisplayVideoInfo());
            Console.WriteLine(video.GetAllComments());
            Console.WriteLine();
        }
        
    }
}