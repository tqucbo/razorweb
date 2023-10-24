using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorEF
{
    public class Article
    {
        [Key]
        public int id { set; get; }
        [StringLength(255)]
        [Required]
        [Column(TypeName = "NVARCHAR")]
        public string title { set; get; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime createDate { set; get; }
        [Column(TypeName = "NTEXT")]
        public string content { set; get; }
    }
}