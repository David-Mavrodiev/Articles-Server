using ArticlesWebApi.Services.Contracts;
using ArticlesWebApi.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ArticlesWebApi.Controllers
{
    public class ArticlesController : ApiController
    {
        private readonly IArticleService articleService;

        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public IEnumerable<ArticleServiceModel> GetAll()
        {
            var articles = this.articleService.GetAll();

            return articles;
        }

        public ArticleServiceModel GetByTitle(string title)
        {
            var article = this.articleService.GetByTitle(title);
            
            return article;
        }

        public ArticleServiceModel Create(string title, string content, string username)
        {
            var serviceModel = new ArticleServiceModel();

            serviceModel.Title = title;
            serviceModel.Content = content;

            this.articleService.Create(serviceModel, username);
            

            return this.articleService.GetByTitle(serviceModel.Title);
        }

        public ArticleServiceModel Update(ArticleServiceModel model)
        {
            this.articleService.Update(model);

            return this.articleService.GetByTitle(model.Title);
        }

        public bool Delete(Guid id)
        {
            this.articleService.Delete(id);

            return true;
        }
    }
}
