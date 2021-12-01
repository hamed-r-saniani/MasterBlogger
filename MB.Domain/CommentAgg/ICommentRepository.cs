using Framework.Infrastructure;
using MB.Application.Contracts.Comment;
using System.Collections.Generic;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long, Comment>
    {
        List<CommentViewModel> GetList();
    }
}
