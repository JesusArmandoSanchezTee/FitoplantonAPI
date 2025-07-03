using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;

namespace Domain.Entities;

public class ClasificationSpecies : AuditableBaseEntry
{
    [Key]
    public int Id { get; set; }
    [StringLength(100)]
    public string Empire { get; set; }
    [StringLength(100)]
    public string Phylum { get; set; }
    [StringLength(100)]
    public string Subphylum { get; set; }
    [StringLength(100)]
    public string Kingdom { get; set; }
    [StringLength(100)]
    public string Class { get; set; }
    [StringLength(100)]
    public string Subclass { get; set; }
    [StringLength(100)]
    public string Order { get; set; }
    [StringLength(100)]
    public string Family { get; set; }
    [StringLength(100)]
    public string Genus { get; set; }
    [ForeignKey(("Species"))]
    public int SpeciesId { get; set; }
    public Species Species { get; set; }
}