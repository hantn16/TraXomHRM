using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TraXomHRM.Areas.Admin.Models.DataModel
{
    [Table("WebPost")]
    public class WebPost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã số")]
        public int PostId { get; set; }
        [Display(Name = "Tiêu đề")]
        [StringLength(512)]
        [Required(ErrorMessage = "Hãy nhập tiêu đề bài viết")]
        public string Title { get; set; }
        [Display(Name = "Mô tả ngắn gọn")]
        [StringLength(1024)]
        [Required(ErrorMessage = "Hãy nhập mô tả ngắn gọn")]
        public string Brief { get; set; }
        [Display(Name = "Nội dung bài viết")]
        [Required(ErrorMessage = "Hãy nhập nội dung")]
        [DataType(DataType.MultilineText)]
        [Column(TypeName ="ntext")]
        [AllowHtml]
        public string Content { get; set; }
        [Display(Name = "Ảnh bài viết")]
        [StringLength(256)]
        public string Picture { get; set; }
        [Display(Name = "Ngày tạo")]
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Thẻ tìm kiếm")]
        [StringLength(128)]
        public string Tags { get; set; }
        [Display(Name = "Mã chủ đề")]
        [ForeignKey("WebCategory")]
        public int CategoryId { get; set; }
        [Display(Name = "Số lần xem")]
        public int ViewNo { get; set; }
        [Display(Name = "Trạng thái")]
        [StringLength(32)]
        public string Status { get; set; }
        [Display(Name = "Mã người dùng")]
        public Guid UserId { get; set; }
        //Thuộc tính Navigation
        public virtual WebCategory WebCategory { get; set; }
        public virtual WebAdministrator WebAdministrator { get; set; }
    }
}