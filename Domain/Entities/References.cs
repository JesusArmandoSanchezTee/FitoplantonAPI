using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class References
{
    [Key]
    public int Id { get; set; }
    [StringLength(300)]
    public string Notes { get; set; }
}