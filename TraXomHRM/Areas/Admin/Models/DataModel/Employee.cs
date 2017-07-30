using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TraXomHRM.Areas.Admin.Models.DataModel
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EmployeeId { get; set; }
        [Display(Name = "Mã nhân viên")]
        [Required(ErrorMessage = "Hãy nhập vào mã nhân viên")]
        [StringLength(8,ErrorMessage = "Mã nhân viên từ 4-8 ký tự",MinimumLength =4)]
        [Column(TypeName ="varchar")]
        public string EmployeeCode { get; set; }
        [Display(Name = "Tên nhân viên")]
        [Required(ErrorMessage = "Hãy nhập vào tên nhân viên")]
        [MaxLength(256)]
        public string EmployeeName { get; set; }
        [Display(Name ="Ngày sinh")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Giới tính",Description = "Nam là 1, Nữ là 0")]
        public byte IsMale { get; set; }
        [Display(Name = "Số CMND")]
        [MaxLength(12)]
        public string IDCardNo { get; set; }
        [Display(Name = "Ngày cấp")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfIssue { get; set; }
        [Display(Name = "Nơi cấp")]
        [MaxLength(64)]
        public string PlaceOfIssue { get; set; }
        [Display(Name = "HKTT")]
        public string PermanentAddress { get; set; }
        [Display(Name = "Nơi ở hiện tại")]
        public string CurrentAddress { get; set; }
        [Display(Name = "Số điện thoại")]
        [StringLength(11,ErrorMessage = "Số điện thoại nhập vào chỉ được phép từ 10-11 ký tự",MinimumLength =10)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Tình trạng hôn nhân",Description = "1: Độc thân, 0: đã kết hôn")]
        public byte IsSingle { get; set; }
        [Display(Name = "Ngày vào làm")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        
        public DateTime JoinDate { get; set; }
        [Display(Name = "Mã User đăng nhập")]
        public Guid? UserId { get; set; }
        [Display(Name = "Mã chức vụ")]
        public int? PositionId { get; set; }
        [Display(Name = "Mã phòng ban")]
        public int? DepartmentId { get; set; }
        //Thuộc tính navigation
        [ForeignKey("UserId")]
        public virtual WebAdministrator WebAdministrator { get; set; }
        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        [InverseProperty("Leader")]
        public virtual ICollection<Department> LedDepartments { get; set; }
    }
}