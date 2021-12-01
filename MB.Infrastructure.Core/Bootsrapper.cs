using Framework.Infrastructure;
using MB.Application;
using MB.Application.Contracts.ApplicationCategory;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.Comment;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repository;
using MB.Infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.Core
{
    public class Bootsrapper
    {
        public static void Configure(IServiceCollection services,string connectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();
            services.AddTransient<IArticleValidatorService, ArticleValidatorService>();
            services.AddTransient<IArticleQuery, ArticleQuery>();
            services.AddTransient<ICommentApplication, CommentApplication>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWorkEF>();
            services.AddDbContext<MasterBloggerContext>(options => {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
