using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using System.Collections.Generic;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void Create(CreateArticleViewModel command)
        {
            var article = new Article(command.Title,command.ShortDescription,command.Image,command.Content,command.ArticleCategoryId);
            _articleRepository.CreateAndSave(article);
        }

        public void Edit(EditArticleViewModel command)
        {
            var article = _articleRepository.GetBy(command.Id);
            article.Edit(command.Title, command.ShortDescription,command.Image, command.Content,command.ArticleCategoryId);
            _articleRepository.Save();
        }

        public EditArticleViewModel GetBy(long id)
        {
            var article = _articleRepository.GetBy(id);
            return new EditArticleViewModel()
            {
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                Image = article.Image,
                Content = article.Content,
                ArticleCategoryId = article.ArticleCategoryId,
                Id = article.Id,
            };
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }
    }
}
