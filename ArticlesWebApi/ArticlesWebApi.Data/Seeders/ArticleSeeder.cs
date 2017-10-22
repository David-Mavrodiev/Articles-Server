using ArticlesWebApi.DataModels;
using System.Linq;

namespace ArticlesWebApi.Data.Seeders
{
    public class ArticleSeeder
    {
        public static void Seed(ArticlesDbContext context)
        {
            var user = context.Users.FirstOrDefault();

            var article1 = new Article()
            {
                Title = "Test 1",
                Content = "Test 1 content",
                User = user
            };

            var comment1 = new Comment()
            {
                Content = "Test comment 1",
                Article = article1,
                Owner = user
            };

            context.Comments.Add(comment1);
            article1.Comments.Add(comment1);
            context.Articles.Add(article1);

            var article2 = new Article()
            {
                Title = "Test 2",
                Content = "Test 2 content",
                User = user
            };

            var comment2 = new Comment()
            {
            Content = "Test comment 2",
            Article = article2,
            Owner = user
            };

            context.Comments.Add(comment2);
            article2.Comments.Add(comment2);
            context.Articles.Add(article2);

            context.SaveChanges();
        }
    }
}
