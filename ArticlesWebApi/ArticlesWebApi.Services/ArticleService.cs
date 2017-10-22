using ArticlesWebApi.Data.Repository.Contracts;
using ArticlesWebApi.DataModels;
using ArticlesWebApi.Services.Contracts;
using ArticlesWebApi.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArticlesWebApi.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IGenericRepository<Article> articleRepository;
        private readonly IGenericRepository<Comment> commentRepository;
        private readonly IGenericRepository<User> userRepository;
        private readonly IUserService userService;

        public ArticleService(IGenericRepository<Article> articleRepository, IGenericRepository<User> userRepository, IGenericRepository<Comment> commentRepository, IUserService userService)
        {
            this.articleRepository = articleRepository;
            this.commentRepository = commentRepository;
            this.userRepository = userRepository;
            this.userService = userService;
        }

        public void AddComment(CommentServiceModel model, string username, string title)
        {
            var article = this.articleRepository.All().Where(a => a.Title == title).FirstOrDefault();
            var user = this.userService.GetByUsername(username);

            var comment = new Comment()
            {
                Content = model.Content,
                Article = article,
                Owner = user
            };

            this.commentRepository.Add(comment);

            article.Comments.Add(comment);
            user.Comments.Add(comment);

            this.articleRepository.Update(article);

            this.userRepository.Update(user);
            this.userRepository.SaveChanges();
        }

        public void Create(ArticleServiceModel model, string username)
        {
            var user = this.userService.GetByUsername(username);

            var article = new Article()
            {
                Title = model.Title,
                Content = model.Content,
                User = user
            };

            this.articleRepository.Add(article);
            this.articleRepository.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var article = this.articleRepository.GetById(id);

            this.articleRepository.Delete(article);
            this.articleRepository.SaveChanges();
        }

        public ArticleServiceModel[] GetAll()
        {
            var articles = this.articleRepository.All().ToList();
            var mappedArticles = new List<ArticleServiceModel>();

            foreach (var article in articles)
            {
                mappedArticles.Add(new ArticleServiceModel()
                {
                    Id = article.Id,
                    Title = article.Title,
                    Content = article.Content,
                    DateCreated = article.DateCreated,
                    DateModified = article.DateModified
                });
            }

            return mappedArticles.ToArray();
        }

        public ArticleServiceModel GetByTitle(string title)
        {
            var article = this.articleRepository.All().Where(a => a.Title == title).FirstOrDefault();

            var mappedArticle = new ArticleServiceModel()
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                DateCreated = article.DateCreated,
                DateModified = article.DateModified
            };

            return mappedArticle;
        }

        public void Update(ArticleServiceModel model)
        {
            var article = this.articleRepository.GetById(model.Id);

            article.Title = model.Title;
            article.Content = model.Content;
            article.DateModified = DateTime.Now;

            this.articleRepository.Update(article);
            this.articleRepository.SaveChanges();
        }
    }
}
