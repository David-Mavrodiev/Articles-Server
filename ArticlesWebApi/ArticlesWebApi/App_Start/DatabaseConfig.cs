using ArticlesWebApi.Data;
using ArticlesWebApi.Data.Migrations;
using System.Data.Entity;

namespace ArticlesWebApi.App_Start
{
    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArticlesDbContext, Configuration>());
            ArticlesDbContext.Create().Database.Initialize(true);
        }
    }
}