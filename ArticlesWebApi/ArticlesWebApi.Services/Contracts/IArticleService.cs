using ArticlesWebApi.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticlesWebApi.Services.Contracts
{
    public interface IArticleService
    {
        ArticleServiceModel[] GetAll();

        ArticleServiceModel GetByTitle(string title);

        void Create(ArticleServiceModel model, string username);

        void Update(ArticleServiceModel model);

        void Delete(Guid id);

        void AddComment(CommentServiceModel model, string username, string title);
    }
}
