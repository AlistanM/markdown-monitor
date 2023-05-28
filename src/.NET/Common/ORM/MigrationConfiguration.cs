using System.Data.Entity.Migrations;

namespace Common.ORM;

internal class MigrationConfiguration : DbMigrationsConfiguration<MainContext>
{
    public MigrationConfiguration()
    {
        AutomaticMigrationsEnabled = true;
        AutomaticMigrationDataLossAllowed = ConfigHelper.Configuration.AllowDataLoss;
        ContextKey = $"{nameof(Common.ORM)}.{nameof(MainContext)}";
    }
}
