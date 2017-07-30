using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TraXomHRM.Areas.Admin.Models.DataModel
{
    [Table("WebBusiness")]
    public class WebBusiness
    {
        [Key]
        [MaxLength(64)]
        [Display(Name = "Mã nghiệp vụ")]
        [Column(TypeName ="varchar")]
        public string BusinessId { get; set; }
        [Required(ErrorMessage = "Hãy nhập tên nghiệp vụ")]
        [Display(Name = "Tên nghiệp vụ")]
        [MaxLength(256)]
        public string BusinessName { get; set; }
        //Thuộc tính navigation
        public virtual ICollection<WebPermission> WebPermissions { get; set; }
    }
}