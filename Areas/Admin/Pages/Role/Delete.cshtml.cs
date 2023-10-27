using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace RazorEF.Role
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : RolePageModel
    {
        public DeleteModel(RoleManager<IdentityRole> roleManager, MyWebContext myWebContext) : base(roleManager, myWebContext)
        {
        }
        public IdentityRole role { set; get; }

        public async Task<IActionResult> OnGetAsync(string roleid)
        {
            if (roleid == null)
                return NotFound("Không tìm thấy vai trò");

            role = await roleManager.FindByIdAsync(roleid);

            if (role == null)
            {
                return NotFound("Không tìm thấy vai trò");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string roleid)
        {
            // var newRole = new IdentityRole("Ten-Role");
            // await roleManager.CreateAsync(newRole);

            if (roleid == null)
                return NotFound("Không tìm thấy vai trò");

            var role = await roleManager.FindByIdAsync(roleid);

            if (role == null)
                return NotFound("Không tìm thấy vai trò");


            var result = await roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                StatusMessage = $"Bạn vừa xoá vai trò {role.Name}";
                return RedirectToPage("./Index");
            }
            else
            {
                result.Errors.ToList().ForEach(
                    (e) => ModelState.AddModelError(string.Empty, e.Description)
                );
                return Page();
            }
        }


    }
}

