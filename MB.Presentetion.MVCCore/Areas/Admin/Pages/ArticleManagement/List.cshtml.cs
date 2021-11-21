using MB.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MB.Presentation.MVCCore.Areas.Admin.Pages.ArticleManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }
        private readonly IArticleApplication _articleApplication;

        public ListModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            Articles = _articleApplication.GetList();
        }
        public IActionResult OnPostActivate(long id)
        {
            _articleApplication.Activate(id);
            return RedirectToAction("./List");
        }
        public IActionResult OnPostRemove(long id)
        {
            _articleApplication.Remove(id);
            return RedirectToAction("./List");
        }
    }
}
