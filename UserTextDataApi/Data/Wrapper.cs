using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserTextDataApi.Data;

public class Wrapper
{
    [Key]
    public string textValue { get; set; }
}