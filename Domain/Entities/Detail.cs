using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;

namespace Domain.Entities;

public class Detail : AuditableBaseEntry
{
    [Key]
    public int Id { get; set; }
    [StringLength(100)]
    public string Description { get; set; }
    [StringLength(100)]
    public string TypeSpecies { get; set; }
    [StringLength(100)]
    public string DetailedDistribution { get; set; }
    public DateTime Date { get; set; }
    [ForeignKey(("Species"))]
    public int SpeciesId { get; set; }
    public Species Species { get; set; }
}