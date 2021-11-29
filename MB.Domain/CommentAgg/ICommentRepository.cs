using MB.Application.Contracts.Comment;
using System.Collections.Generic;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void Add(Comment comment);
        List<CommentViewModel> GetAll();
    }
}
