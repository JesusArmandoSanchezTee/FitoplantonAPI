using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Synonyms
{
    [Key]
    public int Id { get; set; }
    [StringLength(100)]
    public string Name { get; set; }
}