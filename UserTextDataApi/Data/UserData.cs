using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserTextDataApi.Data;

public class UserData
{
    [Key]
    public int Id { get; set; }

    public List<UserText> Texts { get; set; } = new List<UserText>();
}