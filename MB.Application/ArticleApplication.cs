using Framework.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using System;
using System.Collections.Generic;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
        }

        public void Activate(long id)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.GetBy(id);
            article.Activated();
            Commit();
        }

        public void Create(CreateArticleViewModel command)
        {
            var article = new Article(command.Title,command.ShortDescription,command.Image,command.Content,command.ArticleCategoryId);
            _articleRepository.CreateAndSave(article);
        }

        public void Edit(EditArticleViewModel command)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.GetBy(command.Id);
            article.Edit(command.Title, command.ShortDescription,command.Image, command.Content,command.ArticleCategoryId);
            Commit();
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

        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
            var article = _articleRepository.GetBy(id);
            article.Remove();
            Commit();
        }
        private void Commit()
        {
            try
            {
                _unitOfWork.CommitTran();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }
    }
}
