namespace MB.Application.Contracts.Comment
{
    public class AddComment
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public long ArticleId { get; private set; }
    }
}
