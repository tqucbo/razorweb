using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorEF.Role
{
    public class RolePageModel : PageModel
    {
        protected readonly RoleManager<IdentityRole> roleManager;

        private readonly MyWebContext myWebContext;

        [TempData]
        public string StatusMessage { set; get; }

        public RolePageModel(RoleManager<IdentityRole> roleManager, MyWebContext myWebContext)
        {
            this.roleManager = roleManager;
            this.myWebContext = myWebContext;
        }
    }
}