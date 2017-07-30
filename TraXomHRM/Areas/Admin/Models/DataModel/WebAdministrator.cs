using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TraXomHRM.Areas.Admin.Models.DataModel
{
    [Table("WebAdministrator")]
    public class WebAdministrator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Hãy nhập tên người dùng")]
        [StringLength(64, ErrorMessage = "Tên đăng nhập phải từ 4 đến 64 ký tự",MinimumLength =4)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        [MaxLength(256)]
        [Column(TypeName = "varchar")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Hãy nhập họ và tên")]
        [Display(Name = "Họ và tên")]
        [MaxLength(256)]
        public string FullName { get; set; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        [Column(TypeName ="varchar")]
        [MaxLength(256)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Ảnh đại diện")]
        [Column(TypeName ="varchar")]
        [MaxLength(256)]
        public string Avatar { get; set; }
        [Display(Name = "Là quản trị?")]
        public bool IsAdmin { get; set; }
        [Display(Name = "Kích hoạt")]
        public bool IsActive { get; set; }
        //Thuộc tính navigation
        public ICollection<WebGrantPermission> WebGrantPermissions { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}