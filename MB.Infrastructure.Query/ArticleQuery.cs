using MB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _context;

        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }

        public ArticleQueryViewModel GetArticleBy(long id)
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                ArticleCategory = x.ArticleCategory.Title,
                Image = x.Image,
                ShortDescription = x.ShortDescription,
                Content = x.Content
            }).FirstOrDefault(x=>x.Id == id);
        }

        public List<ArticleQueryViewModel> GetArticles()
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                ArticleCategory = x.ArticleCategory.Title,
                Image = x.Image,
                ShortDescription = x.ShortDescription
            }).ToList();
        }
    }
}
