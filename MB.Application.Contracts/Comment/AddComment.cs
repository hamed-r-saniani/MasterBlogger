﻿namespace MB.Application.Contracts.Comment
{
    public class AddComment
    {
        public long Id { get;  set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public string Message { get;  set; }
        public long ArticleId { get;  set; }
    }
}
