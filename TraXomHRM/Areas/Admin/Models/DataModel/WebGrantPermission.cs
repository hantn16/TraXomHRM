using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TraXomHRM.Areas.Admin.Models.DataModel
{
    [Table("WebGrantPermission")]
    public class WebGrantPermission
    {
        [Key]
        [Column(Order =1)]
        [ForeignKey("WebPermission")]
        [Display(Name = "Mã quyền hạn")]
        [Required]
        public int PermissionId { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("WebAdministrator")]
        [Display(Name = "Mã người dùng")]
        [Required]
        public Guid UserId { get; set; }
        [Display(Name = "Mô tả")]
        [MaxLength(256)]
        public string Description { get; set; }
        //Thuộc tính navigation
        public virtual WebPermission WebPermission { get; set; }
        public virtual WebAdministrator WebAdministrator { get; set; }

    }
}