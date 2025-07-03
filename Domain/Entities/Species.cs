using System.ComponentModel.DataAnnotations;
using Domain.Contracts;

namespace Domain.Entities;

public class Species : AuditableBaseEntry
{
    [Key]
    public int Id { get; set; }
    [StringLength(100)]
    public string Habitat { get; set; }
    [StringLength(100)]
    public string Atmosphere { get; set; }
    [StringLength(100)]
    public string Name { get; set; }
    [StringLength(100)]
    public string GeneralAtmosphere { get; set; }
    [StringLength(100)]
    public string TypeSpecie { get; set; }
    
}