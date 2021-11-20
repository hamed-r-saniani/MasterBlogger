namespace MB.Application.Contracts.Article
{
    public class CreateArticleViewModel
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public long ArticleCategoryId { get; set; }
    }
}
