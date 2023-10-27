using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace RazorEF.User
{
    public class AddRoleModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public AddRoleModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public AppUser user { set; get; }

        [BindProperty]
        [DisplayName("Các vài trò đã thiết lập")]
        public List<string> RoleNames { set; get; }

        public SelectList allRoles { set; get; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("Không có thành viên");
            }

            user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound($"Không tìm thấy thành viên có ID : '{id}'.");
            }

            RoleNames = (await _userManager.GetRolesAsync(user)).ToList();

            List<string> roleNames = await _roleManager.Roles.Select(
                (r) => r.Name
            ).ToListAsync();

            allRoles = new SelectList(roleNames);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("Không có thành viên");
            }

            user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound($"Không tìm thấy thành viên có ID : '{id}'.");
            }

            // RoleNames

            var oldRoleNames = (await _userManager.GetRolesAsync(user)).ToList();

            var deleteRoles = oldRoleNames.Where((r) => !RoleNames.Contains(r));

            var addRoles = RoleNames.Where((r) => !oldRoleNames.Contains(r));

            List<string> roleNames = await _roleManager.Roles.Select(
                                        (r) => r.Name
                                            ).ToListAsync();

            allRoles = new SelectList(roleNames);

            var resultDelete = await _userManager.RemoveFromRolesAsync(user, deleteRoles);


            if (!resultDelete.Succeeded)
            {
                resultDelete.Errors.ToList().ForEach(e =>
                    ModelState.AddModelError(string.Empty, e.Description)
                );
                return Page();
            }

            var resultAdd = await _userManager.AddToRolesAsync(user, addRoles);


            if (!resultAdd.Succeeded)
            {
                resultAdd.Errors.ToList().ForEach(e =>
                    ModelState.AddModelError(string.Empty, e.Description)
                );
                return Page();
            }

            // user = await _userManager.FindByIdAsync(id);

            // if (user == null)
            // {
            //     return NotFound($"Không tìm thấy thành viên có ID : '{id}'.");
            // }

            // if (!ModelState.IsValid)
            // {
            //     return Page();
            // }

            // await _userManager.RemovePasswordAsync(user);

            // var addPasswordResult = await _userManager.AddPasswordAsync(user, Input.NewPassword);
            // if (!addPasswordResult.Succeeded)
            // {
            //     foreach (var error in addPasswordResult.Errors)
            //     {
            //         ModelState.AddModelError(string.Empty, error.Description);
            //     }
            //     return Page();
            // }

            // await _signInManager.RefreshSignInAsync(user);
            StatusMessage = $"Đã thiết lập thành công các vai trò cho thành viên : {user.UserName}.";

            return RedirectToPage("./Index");
        }
    }
}
