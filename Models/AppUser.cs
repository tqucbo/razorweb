using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace RazorEF
{
    public class AppUser : IdentityUser
    {
        [Column(TypeName = "NVARCHAR")]
        public string HomeAddress { set; get; }
    }
}