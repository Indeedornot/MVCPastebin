using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserTextDataApi.Data;

public class UserTextData
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key]
    public int Id { get; set; }

    public string Text { get; set; }
}