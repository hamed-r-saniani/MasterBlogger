using MB.Domain.ArticleAgg;
using System;

namespace MB.Domain.CommentAgg
{
    public class Comment
    {
        protected Comment()
        {
           
        }
        public Comment(string name, string email, string message,long articleId)
        {
            Name = name;
            Email = email;
            Message = message;
            ArticleId = articleId;
            Status = Statuses.New;
            CreationDate = DateTime.Now;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public int Status { get; private set; }//0 = New,1 = Confirmed,2 = Cancel
        public DateTime CreationDate { get; private set; }
        public long ArticleId { get; private set; }
        public Article Article { get; private set; }

    }
}
