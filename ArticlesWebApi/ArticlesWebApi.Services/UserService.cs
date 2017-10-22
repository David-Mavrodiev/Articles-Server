using ArticlesWebApi.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesWebApi.DataModels;
using ArticlesWebApi.Data.Repository.Contracts;

namespace ArticlesWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> userRepository;

        public UserService(IGenericRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public User GetByUsername(string username)
        {
            var user = this.userRepository.All().Where(u => u.UserName == username).FirstOrDefault();

            return user;
        }
    }
}
