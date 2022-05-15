using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserTextDataApi.Data;

public class UserTextDataWrapper
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key]
    public int Id { get; set; }

    public ICollection<Wrapper> Texts { get; set; } = new List<Wrapper>();
    
    public UserTextDataWrapper(){}
}