using Framework.Infrastructure;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MB.Infrastructure.EFCore.Repository
{
    public class CommentRepository :BaseRepository<long,Comment>, ICommentRepository
    {
        private readonly MasterBloggerContext _context;
        public CommentRepository(MasterBloggerContext context) : base(context)
        {
            _context = context;
        }

        public List<CommentViewModel> GetList()
        {
            return _context.Comments.Include(_ => _.Article).Select(_ => new CommentViewModel {
                Id = _.Id,
                Email = _.Email,
                Name = _.Name,
                Article = _.Article.Title,
                CreationDate = _.CreationDate.ToString(),
                Message = _.Message,
                Status = _.Status,
            }).ToList();
        }

    }
}
