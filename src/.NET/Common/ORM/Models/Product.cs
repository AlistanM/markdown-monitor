using System.ComponentModel.DataAnnotations;

namespace Common.ORM.Models;

public class Product : BaseEntity
{
    public long OriginalId { get; set; }
    [MaxLength(500)]
    public string Name { get; set; }
    public Category Category { get; set; }
    public long CategoryId { get; set; }
    [MaxLength(500)]
    public string Url { get; set; }
    [MaxLength(500)]
    public string ImageUrl { get; set; }
    public Marketplace Marketplace { get; set; }
}
