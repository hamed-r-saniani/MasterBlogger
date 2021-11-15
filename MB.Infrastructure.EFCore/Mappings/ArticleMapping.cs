using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EFCore.Mappings
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Article");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title);
            builder.Property(x=>x.ShortDescription);
            builder.Property(x => x.Content);
            builder.Property(x => x.Image);
            builder.Property(x => x.CreationDate);
            builder.Property(x => x.IsDelete);
            builder.HasOne(x => x.ArticleCategory).WithMany(x=>x.Articles).HasForeignKey(x=>x.ArticleCategoryId);
        }
    }
}
