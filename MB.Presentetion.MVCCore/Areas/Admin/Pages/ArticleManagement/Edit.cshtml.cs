using MB.Application.Contracts.ApplicationCategory;
using MB.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MB.Presentation.MVCCore.Areas.Admin.Pages.ArticleManagement
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditArticleViewModel Article { get; set; }
        public List<SelectListItem> ArticleCategories { get; set; }
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(long id)
        {
            Article = _articleApplication.GetBy(id);
            ArticleCategories = _articleCategoryApplication.List().Select(x => new SelectListItem(x.Title, x.Id.ToString())).ToList();
        }
        public RedirectToPageResult OnPost()
        {
            _articleApplication.Edit(Article);
            return RedirectToPage("./List");
        }
    }
}
