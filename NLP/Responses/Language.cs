namespace NLPBot.Responses;

public class Language
{
    public Language(string id, string name)
    {
        ID = id;
        Name = name;
    }

    public string ID { get; set; }
    public string Name { get; set; }
}