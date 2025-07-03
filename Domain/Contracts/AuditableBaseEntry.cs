using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Contracts;

public abstract class AuditableBaseEntry
{
    public virtual int Id { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime Created { get; set; }
    
    public int CreatedBy { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime? Modified { get; set; }
    
    public int? ModifiedBy { get; set; }
}