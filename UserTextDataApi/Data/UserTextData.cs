namespace UserTextDataApi.Data;

public class UserTextData
{
    public UserTextData(UserTextDataWrapper? data)
    {
        Id = data!.Id;
        foreach (var text in data.Texts)
        {
            Texts.Add(text.textValue);
        }
    }

    public int Id { get; set; }

    public List<string> Texts { get; set; } = new ();
}