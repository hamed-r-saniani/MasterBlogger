using MB.Application.Contracts.ApplicationCategory;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
        }

        public void Create(CreateArticleCategory command)
        {
            var articleCategory = new ArticleCategory(command.Title,_articleCategoryValidatorService);
            _articleCategoryRepository.Add(articleCategory);
        }

        public RenameArticleCategory GetBy(long id)
        {
            var articleCategory = _articleCategoryRepository.GetBy(id);
            return new RenameArticleCategory
            {
                Title = articleCategory.Title,
                Id = articleCategory.ArticleCategoryId,
            };
        }

        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();
            return (from item in articleCategories
                    select new ArticleCategoryViewModel
                    {

                        Id = item.ArticleCategoryId,
                        Title = item.Title,
                        CreationDate = item.CreationDate.ToString(CultureInfo.InvariantCulture),
                        IsDeleted = item.IsDeleted

                    }).OrderByDescending(x=>x.Id).ToList();
        }

        public void Rename(RenameArticleCategory command)
        {
            var articleCategory = _articleCategoryRepository.GetBy(command.Id);
            articleCategory.Rename(command.Title);
            //_articleCategoryRepository.Save();
        }

        void IArticleCategoryApplication.Activate(long id)
        {
            var articleCategory = _articleCategoryRepository.GetBy(id);
            articleCategory.Activate();
            //_articleCategoryRepository.Save();
        }

        void IArticleCategoryApplication.Remove(long id)
        {
            var articleCategory = _articleCategoryRepository.GetBy(id);
            articleCategory.Remove();
            //_articleCategoryRepository.Save();
        }
    }
}
