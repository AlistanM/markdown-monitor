using System.ComponentModel.DataAnnotations;

namespace Common.ORM.Models;

public class SearchString : BaseEntity
{
    [MaxLength(200)]
    public string QueryString { get; set; }
    public MarketplaceFlags Marketplaces { get; set; }
    public bool IsDeleted { get; set; } = false;
}
