using ArticlesWebApi.Data.Contracts;
using ArticlesWebApi.DataModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ArticlesWebApi.Data
{
    public class ArticlesDbContext : IdentityDbContext<User>, IArticlesDbContext
    {
        public ArticlesDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Article> Articles { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public static ArticlesDbContext Create()
        {
            return new ArticlesDbContext();
        }
    }
}
