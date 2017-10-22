using ArticlesWebApi.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesWebApi.Services.Contracts
{
    public interface IUserService
    {
        User GetByUsername(string username);
    }
}
