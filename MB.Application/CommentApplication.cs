using Framework.Infrastructure;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;
using System;
using System.Collections.Generic;

namespace MB.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddComment command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.Add(comment);
        }

        public void Cancel(long id)
        {
            _unitOfWork.BeginTran();
            var comment = _commentRepository.GetBy(id);
            comment.Cancel();
            Commit();
        }

        public void Confirm(long id)
        {
            _unitOfWork.BeginTran();
            var comment = _commentRepository.GetBy(id);
            comment.Confirm();
            Commit();
        }

        public List<CommentViewModel> GetList()
        {
            return _commentRepository.GetList();
        }
        private void Commit()
        {
            try
            {
                _unitOfWork.CommitTran();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
            }
        }
    }
}
