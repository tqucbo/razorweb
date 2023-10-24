using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorEF;

namespace CS0058_Entity_Framework_Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly MyWebContext myWebContext;

        public IndexModel(ILogger<IndexModel> logger, MyWebContext myWebContext)
        {
            _logger = logger;
            this.myWebContext = myWebContext;
        }

        public void OnGet()
        {
            var posts = (from p in myWebContext.articles
                         orderby p.createDate descending
                         select p).ToList();
            ViewData["posts"] = posts;
        }
    }
}
