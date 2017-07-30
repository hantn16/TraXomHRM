using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TraXomHRM.Areas.Admin.Models.DataModel
{
    [Table("WebCategory")]
    public class WebCategory
    {
        [Key]
        [Display(Name = "Mã chủ đề")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Display(Name = "Tên chủ đề")]
        [Required(ErrorMessage = "Hãy nhập tên chủ đề")]
        [StringLength(256)]
        public string CategoryName { get; set; }
        [Display(Name = "Thứ tự xuất hiện")]
        [Required(ErrorMessage = "Hãy nhập thứ tự xuất hiện của chủ đề")]
        public int OrderNo { get; set; }
        [Display(Name = "Trạng thái")]
        [StringLength(32)]
        public string Status { get; set; }
        [Display(Name = "Mã người dùng")]
        public Guid? UserId { get; set; }
        //Thuộc tính navigation
        public virtual WebAdministrator WebAdministrator { get; set; }
        public virtual ICollection<WebPost> WebPosts { get; set; }
    }
}