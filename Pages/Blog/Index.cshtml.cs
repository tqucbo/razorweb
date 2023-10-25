using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorEF;

namespace CS0058_Entity_Framework_Razor.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly RazorEF.MyWebContext _context;

        public IndexModel(RazorEF.MyWebContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get; set; }

        public const int ITEMS_PER_PAGE = 10;

        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { set; get; }

        public int countPages { set; get; }

        public async Task OnGetAsync(string searchString)
        {
            // Article = await _context.articles.ToListAsync();

            int totalArticle = await _context.articles.CountAsync();

            countPages = (int)Math.Ceiling((double)totalArticle / ITEMS_PER_PAGE);

            if (currentPage < 1)
            {
                currentPage = 1;
            }
            if (currentPage > countPages)
            {
                currentPage = countPages;
            }

            var linqQuery = (from a in _context.articles
                             orderby a.createDate descending
                             select a)
                             .Skip((currentPage - 1) * 10)
                             .Take(ITEMS_PER_PAGE);

            if (!string.IsNullOrEmpty(searchString))
            {
                Article = linqQuery.Where((a) => a.title.Contains(searchString)).ToList();

            }
            else
            {
                Article = await linqQuery.ToArrayAsync();
            }

        }
    }
}
