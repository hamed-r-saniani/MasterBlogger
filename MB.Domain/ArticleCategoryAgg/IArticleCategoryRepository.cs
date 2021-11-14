using System.Collections.Generic;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> GetAll();
        void Add(ArticleCategory entity);
        ArticleCategory GetBy(long id);
        void Save();
        bool CheckBy(string title);
    }
}
