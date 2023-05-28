using Common.ORM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Common.ORM;

internal class MainContext : DbContext
{
    public MainContext() : base(ConfigHelper.Configuration.DataConnectionString)
    {
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<MainContext, MigrationConfiguration>());
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SessionProduct> SessionProducts { get; set; }
    public DbSet<SessionSearchString> SessionSearchStrings { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<SearchString> SearchStrings { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        #region Category
        modelBuilder.Entity<Category>()
            .Property(x => x.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        modelBuilder.Entity<Category>().HasKey(x => x.Id);

        modelBuilder.Entity<Category>().Property(x => x.Name);
        modelBuilder.Entity<Category>().HasOptional(x => x.ParentCategory);
        #endregion

        #region Product
        modelBuilder.Entity<Product>()
            .Property(x => x.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        modelBuilder.Entity<Product>().HasKey(x => x.Id);

        modelBuilder.Entity<Product>().Property(x => x.Name);
        modelBuilder.Entity<Product>().Property(x => x.OriginalId);
        modelBuilder.Entity<Product>().HasIndex(x => x.OriginalId);
        modelBuilder.Entity<Product>()
            .HasRequired(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId);
        #endregion

        #region SessionProduct
        modelBuilder.Entity<SessionProduct>()
            .Property(x => x.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        modelBuilder.Entity<SessionProduct>().HasKey(x => x.Id);

        modelBuilder.Entity<SessionProduct>().Property(x => x.Available);
        modelBuilder.Entity<SessionProduct>().Property(x => x.OriginalPrice).HasPrecision(18, 2);
        modelBuilder.Entity<SessionProduct>().Property(x => x.Price).HasPrecision(18, 2);
        modelBuilder.Entity<SessionProduct>().Property(x => x.Rating);
        modelBuilder.Entity<SessionProduct>().HasRequired(x => x.Product);
        modelBuilder.Entity<SessionProduct>()
            .HasRequired(x => x.Session)
            .WithMany(x => x.SessionProducts)
            .HasForeignKey(x => x.SessionId);
        #endregion

        #region SearchString
        modelBuilder.Entity<SearchString>()
            .Property(x => x.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        modelBuilder.Entity<SearchString>().HasKey(x => x.Id);

        modelBuilder.Entity<SearchString>().Property(x => x.StringQueryString);
        #endregion

        #region SessionSearchString
        modelBuilder.Entity<SessionSearchString>()
            .Property(x => x.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        modelBuilder.Entity<SessionSearchString>().HasKey(x => x.Id);

        modelBuilder.Entity<SessionSearchString>().HasRequired(x => x.SearchString);
        modelBuilder.Entity<SessionSearchString>()
            .HasRequired(x => x.Session)
            .WithMany(x => x.SessionSearchStrings)
            .HasForeignKey(x => x.SessionId);
        #endregion

        #region Session
        modelBuilder.Entity<Session>()
            .Property(x => x.Id)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        modelBuilder.Entity<Session>().HasKey(x => x.Id);

        modelBuilder.Entity<Session>().Property(x => x.SessionDate).IsRequired();
        #endregion
    }
}
