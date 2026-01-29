public class Comment
{
    private string _name;
    private string _text;

    public Comment(string name, string comment)
    {
        _name = name;
        _text = comment;
    }
    
    public string DisplayComment()
    {
        string comment = $"{_name}: {_text}";
        return comment;
    }
}