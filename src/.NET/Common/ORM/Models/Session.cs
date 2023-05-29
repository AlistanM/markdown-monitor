using System.ComponentModel.DataAnnotations;

namespace Common.ORM.Models;

public class Session : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public SessionStatus Status { get; set; }
    [MaxLength(1000)]
    public string ErrorMessage { get; set; }
    public List<SessionProduct> SessionProducts { get; set; }
    public List<SessionSearchString> SessionSearchStrings { get; set; }
}
