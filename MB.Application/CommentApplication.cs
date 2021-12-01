using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using System.Collections.Generic;

namespace MB.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Add(AddComment command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.Add(comment);
        }

        public void Cancel(long id)
        {
            var comment = _commentRepository.GetBy(id);
            comment.Cancel();
            //_commentRepository.Save();
        }

        public void Confirm(long id)
        {
            var comment = _commentRepository.GetBy(id);
            comment.Confirm();
            //_commentRepository.Save();
        }

        public List<CommentViewModel> GetList()
        {
            return _commentRepository.GetList();
        }
    }
}
