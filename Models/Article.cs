using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorEF
{
    public class Article
    {
        [Key]
        public int id { set; get; }
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Tiêu đề phải có độ dài {2} đến {1} ký tự.")]
        [Required(ErrorMessage = "{0} không được bỏ trống.")]
        [Column(TypeName = "NVARCHAR")]
        [DisplayName("Tiêu đề")]
        public string title { set; get; }
        [DataType(DataType.Date)]
        [DisplayName("Ngày tạo")]
        [Required(ErrorMessage = "{0} không được bỏ trống.")]
        public DateTime createDate { set; get; }
        [Column(TypeName = "NTEXT")]
        [DisplayName("Nội dung")]
        public string content { set; get; }
    }
}