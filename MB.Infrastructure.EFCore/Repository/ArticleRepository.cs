using MB.Domain.ArticleAgg;

namespace MB.Infrastructure.EFCore.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MasterBloggerContext _masterBloggerContext;

        public ArticleRepository(MasterBloggerContext masterBloggerContext)
        {
            _masterBloggerContext = masterBloggerContext;
        }

    }
}
