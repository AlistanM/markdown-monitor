using System.ComponentModel.DataAnnotations;

namespace Common.ORM.Models;

public class Session : BaseEntity
{
    public DateTime SessionDate { get; set; }
    public List<SessionProduct> SessionProducts { get; set; }
    public List<SessionSearchString> SessionSearchStrings { get; set; }
}
