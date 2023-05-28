using Common.ORM.Models;
using System.Data.Entity;

namespace Common.Interfaces;

public interface IDbRepository : IDisposable
{
    IQueryable<Category> GetCategories();
    IQueryable<Product> GetProducts();
    IQueryable<SearchString> GetSearchStrings();
    IQueryable<Session> GetSessions();
    IQueryable<SessionSearchString> GetSessionsSearchStrings();
    IQueryable<SessionProduct> GetSessionsProducts();

    void Save();
    void Add<T>(T entity) where T : BaseEntity;
    void Update<T>(T entity) where T : BaseEntity;
    void Remove<T>(T entity) where T : BaseEntity;
}
