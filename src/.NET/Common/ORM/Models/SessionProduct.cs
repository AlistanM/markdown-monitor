using System.ComponentModel.DataAnnotations;

namespace Common.ORM.Models;

public class SessionProduct : BaseEntity
{
    public long SessionId { get; set; }
    public Session Session { get; set; }
    public Product Product { get; set; }
    public decimal Price { get; set; }
    public decimal OriginalPrice { get; set; }
    public bool Available { get; set; }
    public float Rating { get; set; }
}
