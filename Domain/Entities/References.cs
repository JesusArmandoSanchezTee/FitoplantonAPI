using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;

namespace Domain.Entities;

public class References : AuditableBaseEntry
{
    [Key]
    public int Id { get; set; }
    [StringLength(300)]
    public string Notes { get; set; }
    [ForeignKey(("Species"))]
    public int SpeciesId { get; set; }
    public Species Species { get; set; }
}