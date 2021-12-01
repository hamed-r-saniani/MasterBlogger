using Framework.Infrastructure;
using MB.Domain.ArticleCategoryAgg;
using System;

namespace MB.Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepository :BaseRepository<long,ArticleCategory>, IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context) : base(context)
        {
            _context = context;
        }

 
    }
}
