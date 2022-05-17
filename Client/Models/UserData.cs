namespace Client.Models;

public class UserData
{
    public int Id { get; set; }

    public List<UserText> Texts { get; set; } = new List<UserText>();
    
    public UserData(){}
}