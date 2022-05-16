using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Client.Models;

namespace UserTextDataApi.Data;

public class UserData
{
    public int Id { get; set; }

    public List<UserText> Texts { get; set; } = new List<UserText>();
    
    public UserData(){}
}