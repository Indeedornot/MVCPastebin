using System.ComponentModel.DataAnnotations;

namespace Client.Models;

public class UserText
{
    public UserText(string text)
    {
        textValue = text;
    }

    public UserText()
    {
    }
    
    public string textValue { get; set; }
}