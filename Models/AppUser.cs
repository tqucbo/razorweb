using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace RazorEF
{
    public class AppUser : IdentityUser
    {
        [Column(TypeName = "NVARCHAR")]
        [StringLength(400)]
        public string HomeAddress { set; get; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { set; get; }
    }
}