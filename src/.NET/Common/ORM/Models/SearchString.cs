using System.ComponentModel.DataAnnotations;

namespace Common.ORM.Models;

public class SearchString : BaseEntity
{
    [MaxLength(200)]
    public string StringQueryString { get; set; }
    public MarketplaceFlags Marketplaces { get; set; }
}
