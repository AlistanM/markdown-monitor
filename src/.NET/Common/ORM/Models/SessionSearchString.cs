namespace Common.ORM.Models;

public class SessionSearchString : BaseEntity
{
    public Session Session { get; set; }
    public long SessionId { get; set; }
    public SearchString SearchString { get; set; }
    public List<SessionProduct> SessionProducts { get; set; }
}
