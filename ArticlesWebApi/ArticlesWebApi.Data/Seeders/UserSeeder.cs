using ArticlesWebApi.DataModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ArticlesWebApi.Data.Seeders
{
    public class UserSeeder
    {
        public static void Seed(ArticlesDbContext context)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            var user = new User()
            {
                UserName = "Pesho",
                Email = "pesho@abv.bg"
            };

            userManager.Create(user, "123456");

            context.SaveChanges();
        }
    }
}
