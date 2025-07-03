using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;

namespace Domain.Entities;

public class Synonyms : AuditableBaseEntry
{
    [Key]
    public int Id { get; set; }
    [StringLength(100)]
    public string Name { get; set; }
    [ForeignKey(("Species"))]
    public int SpeciesId { get; set; }
    public Species Species { get; set; }
}