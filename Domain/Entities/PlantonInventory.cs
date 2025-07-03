using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Contracts;

namespace Domain.Entities;

public class PlantonInventory : AuditableBaseEntry
{
    [Key]
    public int Id { get; set; }
    [StringLength(100)]
    public string Description { get; set; }
    [StringLength(100)]
    public string Location { get; set; }
    [StringLength(100)]
    public string Image { get; set; }
    [StringLength(100)]
    public string Title { get; set; }
    [ForeignKey(("Species"))]
    public int SpeciesId { get; set; }
    public Species Species { get; set; }
}