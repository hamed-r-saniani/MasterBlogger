using Framework.Domain;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using System;
using System.Collections.Generic;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : DomainBase<long>
    {
        public long ArticleCategoryId { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public IEnumerable<Article> Articles { get; private set; }
        public ArticleCategory(string title,IArticleCategoryValidatorService validatorService)
        {
            CheckTitleIsNullOrEmpty(title);
            validatorService.CheckThatThisRecordAlreadyExist(title);
            Title = title;
            IsDeleted = false;
            Articles = new List<Article>();
        }

        protected ArticleCategory()
        {
        }

        private static void CheckTitleIsNullOrEmpty(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException("title");
        }

        public void Rename(string title)
        {
            CheckTitleIsNullOrEmpty(title);
            Title = title;
        }

        public void Remove() => IsDeleted = true;

        public void Activate() => IsDeleted = false;
    }
}
