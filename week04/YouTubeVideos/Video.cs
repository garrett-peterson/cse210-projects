public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length) {
        _title = title;
        _author = author;
        _length = length;     
    }

    public int CommentCount()
    {
        return _comments.Count;
    }

    public string DisplayVideoInfo()
    {
        int numbComments = CommentCount();
        string formattedInfo = $"Video Title: {_title}\nAuthor: {_author}\nThe video is {_length} seconds long\nNumber of comments: {numbComments}";
        return formattedInfo;
    }

    public void AddComment(string author, string comment)
    {
       Comment com = new Comment(author, comment);
       _comments.Add(com);
    }

    public string GetAllComments()
    {
        string comments = "";
        foreach (Comment comment in _comments)
        {
            string text = comment.DisplayComment();
            comments += text;
            comments += "\n";
        }

        return comments;
    }
}