﻿using MB.Application;
using MB.Application.Contracts.ApplicationCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repository;
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
            services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();
            services.AddDbContext<MasterBloggerContext>(options => {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
