using System.ComponentModel.DataAnnotations;

namespace UserTextDataApi.Data;

public class UserText
{
    public UserText(string text)
    {
        TextValue = text;
    }
    
    public UserText(){}
    
    [Key]
    public int Id { get; set; }
    public string TextValue { get; set; }
}