using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
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
                Content = x.Content,
                CommentsCount = x.Comments.Count(x=>x.Status == Statuses.Confirmed),
                Comments = MapComments(x.Comments.Where(p=>p.Status == Statuses.Confirmed))
            }).FirstOrDefault(x=>x.Id == id);
        }

        private List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        {
            return comments.Select(x => new CommentQueryView { CreationDate = x.CreationDate.ToString(), Message = x.Message, Name = x.Name }).ToList();
        }

        public List<ArticleQueryViewModel> GetArticles()
        {
            return _context.Articles.Include(x => x.ArticleCategory).Include(x=>x.Comments).Select(x => new ArticleQueryViewModel
            {
                Id = x.Id,
                Title = x.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                ArticleCategory = x.ArticleCategory.Title,
                Image = x.Image,
                ShortDescription = x.ShortDescription,
                CommentsCount = x.Comments.Count(x=>x.Status == Statuses.Confirmed)
            }).ToList();
        }
    }
}
