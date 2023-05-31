using System.ComponentModel.DataAnnotations;

namespace Common.ORM.Models;

public class SessionProduct : BaseEntity
{
    public long SessionSearchStringId { get; set; }
    public SessionSearchString SessionSearchString { get; set; }
    public Product Product { get; set; }
    public decimal Price { get; set; }
    public decimal OriginalPrice { get; set; }
    public bool Available { get; set; }
    public float Rating { get; set; }
}
