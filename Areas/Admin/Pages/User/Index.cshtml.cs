using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorEF.User
{
    [Authorize]
    public class IndexModel : PageModel
    {
        [TempData]
        public string StatusMessage { set; get; }

        private readonly UserManager<AppUser> userManager;
        public IndexModel(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public class AppUserAndRole : AppUser
        {
            public string roleNames { set; get; }
        }

        public List<AppUserAndRole> users { set; get; }

        public const int ITEMS_PER_PAGE = 10;

        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { set; get; }

        public int countPages { set; get; }

        public int totalUser { set; get; }

        public async Task OnGetAsync()
        {
            // users = await appManager.Users.OrderBy((u) => u.UserName).ToListAsync();
            var query = userManager.Users.OrderBy((u) => u.UserName);

            totalUser = await query.CountAsync();

            countPages = (int)Math.Ceiling((double)totalUser / ITEMS_PER_PAGE);

            if (currentPage < 1)
            {
                currentPage = 1;
            }
            if (currentPage > countPages)
            {
                currentPage = countPages;
            }

            var query1 = query
                            .Skip((currentPage - 1) * ITEMS_PER_PAGE)
                            .Take(ITEMS_PER_PAGE)
                            .Select((u) => new AppUserAndRole()
                            {
                                Id = u.Id,
                                UserName = u.UserName,
                            });

            users = await query1.ToListAsync();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);
                user.roleNames = string.Join(", ", roles);
            }
        }

        public void OnPost() => RedirectToPage();
    }
}
