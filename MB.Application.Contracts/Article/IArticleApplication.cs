using System.Collections.Generic;

namespace MB.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetList();
        void Create(CreateArticleViewModel command);
        void Edit(EditArticleViewModel command);
        EditArticleViewModel GetBy(long id);
    }
}
