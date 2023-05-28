using Common.Interfaces;
using Common.ORM.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Security.Cryptography.X509Certificates;

namespace Common.ORM;

internal class DbRepository : IDbRepository
{
    private MainContext _context;

    public DbRepository()
    {
        _context = new MainContext();
    }

    public IQueryable<Category> GetCategories()
    {
        return _context.Categories
            .Include(x => x.Products)
            .Include(x => x.ParentCategory);
    }

    public IQueryable<Product> GetProducts()
    {
        return _context.Products
            .Include(x => x.Category);
    }

    public IQueryable<SearchString> GetSearchStrings()
    {
        return _context.SearchStrings;
    }

    public IQueryable<Session> GetSessions()
    {
        return _context.Sessions
            .Include(x => x.SessionProducts)
            .Include(x => x.SessionSearchStrings);
    }

    public IQueryable<SessionProduct> GetSessionsProducts()
    {
        return _context.SessionProducts
            .Include(x => x.Product)
            .Include(x => x.Session);
    }

    public IQueryable<SessionSearchString> GetSessionsSearchStrings()
    {
        return _context.SessionSearchStrings
            .Include(x => x.Session)
            .Include(x => x.SearchString);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void Add<T>(T entity) where T : BaseEntity
    {
        GetEntityStorage<T>().Add(entity);
    }

    public void Update<T>(T entity) where T : BaseEntity
    {
        var storage = GetEntityStorage<T>();
        var instance = storage.Find(entity.Id);
        if (instance == null)
        {
            throw new Exception($"Entitiy not found. Type '{typeof(T).Name}'");
        }
        _context.Entry(instance).CurrentValues.SetValues(entity);
    }

    public void Remove<T>(T entity) where T : BaseEntity
    {
        var storage = GetEntityStorage<T>();
        storage.Attach(entity);
        storage.Remove(entity);
    }

    private DbSet<T> GetEntityStorage<T>() where T : class
    {
        var storages = typeof(MainContext).GetProperties();
        var targetProperty = storages.SingleOrDefault(x => x.PropertyType == typeof(DbSet<T>));
        if (targetProperty == null)
        {
            throw new Exception($"Database does not contain type '{typeof(T).Name}'");
        }
        return targetProperty.GetValue(_context) as DbSet<T>;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
