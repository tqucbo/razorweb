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
    public class EditModel : RolePageModel
    {
        public EditModel(RoleManager<IdentityRole> roleManager, MyWebContext myWebContext) : base(roleManager, myWebContext)
        {
        }

        public class InputModel
        {
            [DisplayName("Tên của Vai trò")]
            [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} phải có độ dài từ {2} đến {1} ký tự.")]
            [Required(ErrorMessage = "{0} không được bỏ trống.")]
            public string nameOfRole { set; get; }
        }

        [BindProperty]
        public InputModel inputModel { set; get; }

        public IdentityRole role { set; get; }

        public async Task<IActionResult> OnGetAsync(string roleid)
        {
            if (roleid == null)
                return NotFound("Không tìm thấy vai trò");

            role = await roleManager.FindByIdAsync(roleid);

            if (role != null)
            {
                inputModel = new InputModel()
                {
                    nameOfRole = role.Name
                };
                return Page();
            }
            return NotFound("Không tìm thấy vai trò");
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

            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                role.Name = inputModel.nameOfRole;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    StatusMessage = $"Bạn vừa đổi tên vai trò : {inputModel.nameOfRole}";
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
}
