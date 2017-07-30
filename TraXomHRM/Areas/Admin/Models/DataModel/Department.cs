using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TraXomHRM.Areas.Admin.Models.DataModel
{
    [Table("Department")]
    public class Department
    {
        public Department()
        {

        }
        public Department(string name)
        {
            DepartmentName = name;
        }
        public Department(string name,int parentid)
        {
            DepartmentName = name;
            ParentId = parentid;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã phòng ban")]
        public int DepartmentId { get; set; }
        [Display(Name = "Tên phòng ban")]
        [MaxLength(256)]
        [Required(ErrorMessage = "Hãy nhập tên phòng ban")]
        public string DepartmentName { get; set; }
        public int? ParentId { get; set; }
        public Guid? LeaderId { get; set; }
        //Thuộc tính navigation
        [InverseProperty("Department")]
        public virtual ICollection<Employee> Employees { get; set; }
        [ForeignKey("LeaderId")]
        public virtual Employee Leader { get; set; }
        [ForeignKey("ParentId")]
        public virtual Department ParentDepartment { get; set; }
    }
}