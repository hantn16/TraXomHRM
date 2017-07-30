namespace TraXomHRM.Migrations
{
    using Areas.Admin.Models.BusinessModel;
    using Areas.Admin.Models.DataModel;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TraXomHRM.Areas.Admin.Models.BusinessModel.WebDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TraXomHRM.Areas.Admin.Models.BusinessModel.WebDbContext";
        }

        protected override void Seed(TraXomHRM.Areas.Admin.Models.BusinessModel.WebDbContext context)
        {
            //Khởi tạo user mẫu
            //var admin = new WebAdministrator()
            //{
            //    UserName = "admin",
            //    Password = Common.EncryptMD5("adminanhhan"),
            //    FullName = "Trịnh Ngọc Hân",
            //    Avatar = "/Areas/Admin/Content/images/admin.jpg",
            //    Email = "hantn16@gmail.com",
            //    IsAdmin = true,
            //    IsActive = true
            //};
            //context.Administrators.Add(admin);
            //var user01 = new WebAdministrator()
            //{
            //    UserName = "user01",
            //    Password = Common.EncryptMD5("user01anhhan"),
            //    FullName = "Nguyễn Văn A",
            //    Avatar = "/Areas/Admin/Content/images/user01.png",
            //    Email = "user01@gmail.com",
            //    IsAdmin = false,
            //    IsActive = true
            //};
            //context.Administrators.Add(user01);
            ////Khởi tạo phòng ban
            //var bpvp = new Department("Bộ Phận Văn Phòng");
            //context.Departments.Add(bpvp);
            //var pxvh = new Department("Phân xưởng vận hành");
            //context.Departments.Add(pxvh);
            //var phongnhansu = new Department("Phòng Nhân Sự", 1);
            //context.Departments.Add(phongnhansu);
            //var phongketoan = new Department("Phòng Kế Toán", 1);
            //context.Departments.Add(phongketoan);
            //var phongktkh = new Department("Phòng Kinh Tế - Kế Hoạch", 1);
            //context.Departments.Add(phongktkh);
            //var phongqlkt = new Department("Phòng Quản Lý - Kỹ Thuật", 1);
            //context.Departments.Add(phongqlkt);
            //var bql = new Department("Ban Giám Đốc", 1);
            //context.Departments.Add(bql);
            //var tokt = new Department("Tổ kỹ thuật", 2);
            //context.Departments.Add(tokt);
            //var tovh = new Department("Tổ vận hành", 2);
            //context.Departments.Add(tovh);
            ////Khởi tạo chức vụ
            //var gd = new Position("GD", "Giám Đốc", 0);
            //context.Positions.Add(gd);
            //var pgd = new Position("PGD", "Phó Giám Đốc", 0);
            //context.Positions.Add(pgd);
            //var tp = new Position("TP", "Trưởng Phòng", 0);
            //context.Positions.Add(tp);
            //var pp = new Position("PP", "Phó Phòng", 0);
            //context.Positions.Add(pp);
            //var cv = new Position("CV", "Chuyên Viên", 0);
            //context.Positions.Add(cv);
            //var nv = new Position("NV", "Nhân Viên", 0);
            //context.Positions.Add(nv);
            ////Lưu thay đổi
            //context.SaveChanges();
        }
    }
}
