using System.Collections.Generic;

namespace MB.Infrastructure.Query
{
    public interface IArticleQuery
    {
        List<ArticleQueryViewModel> GetArticles();
        ArticleQueryViewModel GetArticleBy(long id);
    }
}
