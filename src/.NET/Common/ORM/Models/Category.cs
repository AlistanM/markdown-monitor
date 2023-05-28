using System.ComponentModel.DataAnnotations;

namespace Common.ORM.Models;

public class Category : BaseEntity
{
    [MaxLength(500)]
    public string Name { get; set; }
    public Category ParentCategory { get; set; }
    public List<Product> Products { get; set; }
}
