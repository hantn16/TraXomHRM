using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TraXomHRM.Areas.Admin.Models.DataModel
{
    [Table("WebPermission")]
    public class WebPermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PermissionId { get; set; }
        [Display(Name = "Tên quyền hạn")]
        [Required(ErrorMessage = "Hãy nhập tên quyền hạn")]
        [Column(TypeName ="varchar")]
        [MaxLength(256)]
        public string PermissionName { get; set; }
        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Hãy nhập mô tả quyền hạn")]
        [MaxLength(256)]
        public string Description { get; set; }
        [Required()]
        [MaxLength(64)]
        [Display(Name = "Mã nghiệp vụ")]
        [ForeignKey("WebBusiness")]
        [Column(TypeName = "varchar")]
        public string BusinessId { get; set; }
        //Thuộc tính navigation
        public virtual WebBusiness WebBusiness { get; set; }
        public virtual ICollection<WebGrantPermission> WebGrantPermissions { get; set; }
    }
}