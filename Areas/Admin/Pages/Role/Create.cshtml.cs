using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RazorEF.Role
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : RolePageModel
    {
        public CreateModel(RoleManager<IdentityRole> roleManager, MyWebContext myWebContext) : base(roleManager, myWebContext)
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

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // var newRole = new IdentityRole("Ten-Role");
            // await roleManager.CreateAsync(newRole);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                var newRole = new IdentityRole(inputModel.nameOfRole);
                var result = await roleManager.CreateAsync(newRole);
                if (result.Succeeded)
                {
                    StatusMessage = $"Bạn vừa tạo vai trò mới : {inputModel.nameOfRole}";
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
