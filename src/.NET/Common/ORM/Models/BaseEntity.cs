using System.ComponentModel.DataAnnotations;

namespace Common.ORM.Models;

public abstract class BaseEntity
{
    [Key]
    public long Id { get; set; }
}
