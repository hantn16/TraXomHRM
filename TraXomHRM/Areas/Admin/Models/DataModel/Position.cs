using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TraXomHRM.Areas.Admin.Models.DataModel
{
    [Table("Position")]
    public class Position
    {
        public Position()
        {
            PositionCode = null;
            PositionName = null;
            AllowanceRate = 0;
        }
        public Position(string machucvu,string tenchucvu,double hesophucap)
        {
            PositionCode = machucvu;
            PositionName = tenchucvu;
            AllowanceRate = hesophucap;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PositionId { get; set; }
        [Display(Name = "Mã chức vụ")]
        [StringLength(4,ErrorMessage = "Mã chức vụ chỉ được phép từ 2 đển 4 ký tự", MinimumLength =2)]
        [Required(ErrorMessage = "Hãy nhập vào Mã chức vụ")]
        public string PositionCode { get; set; }
        [Display(Name = "Tên chức vụ")]
        [MaxLength(64)]
        [Required(ErrorMessage = "Hãy nhập vào tên chức vụ")]
        public string PositionName { get; set; }
        [Display(Name = "Hệ số phụ cấp chức vụ")]
        [Required(ErrorMessage = "Hãy nhập vào hệ số phụ cấp chức vụ")]
        public double AllowanceRate { get; set; }
        //Thuộc tính navigation
        public ICollection<Employee> Employees { get; set; }
    }
}