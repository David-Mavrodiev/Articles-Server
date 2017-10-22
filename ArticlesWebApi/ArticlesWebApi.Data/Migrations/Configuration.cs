namespace ArticlesWebApi.Data.Migrations
{
    using ArticlesWebApi.Data.Seeders;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ArticlesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ArticlesDbContext context)
        {
            if (!context.Users.Any())
            {
                UserSeeder.Seed(context);
            }

            if (!context.Articles.Any())
            {
                ArticleSeeder.Seed(context);
            }
        }
    }
}
