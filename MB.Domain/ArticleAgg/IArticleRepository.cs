using Framework.Infrastructure;
using MB.Application.Contracts.Article;
using System.Collections.Generic;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long,Article>
    {
        List<ArticleViewModel> GetList();
        void CreateAndSave(Article article);

    }
}
