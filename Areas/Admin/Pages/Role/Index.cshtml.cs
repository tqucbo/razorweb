using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorEF.Role
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : RolePageModel
    {
        public IndexModel(RoleManager<IdentityRole> roleManager, MyWebContext myWebContext) : base(roleManager, myWebContext)
        {
        }

        public List<IdentityRole> roles { set; get; }

        public async Task OnGet()
        {
            roles = await roleManager.Roles.OrderBy(
                (r) => r.Name
            ).ToListAsync();
        }

        public void OnPost() => RedirectToPage();
    }
}
