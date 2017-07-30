namespace TraXomHRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1stMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WebAdministrator",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 64, unicode: false),
                        Password = c.String(nullable: false, maxLength: 256, unicode: false),
                        FullName = c.String(nullable: false, maxLength: 256),
                        Email = c.String(maxLength: 256, unicode: false),
                        Avatar = c.String(maxLength: 256, unicode: false),
                        IsAdmin = c.Byte(),
                        IsActive = c.Byte(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.WebGrantPermission",
                c => new
                    {
                        PermissionId = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Description = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => new { t.PermissionId, t.UserId })
                .ForeignKey("dbo.WebAdministrator", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.WebPermission", t => t.PermissionId, cascadeDelete: true)
                .Index(t => t.PermissionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WebPermission",
                c => new
                    {
                        PermissionId = c.Int(nullable: false, identity: true),
                        PermissionName = c.String(nullable: false, maxLength: 256, unicode: false),
                        Description = c.String(nullable: false, maxLength: 256),
                        BusinessId = c.String(nullable: false, maxLength: 64, unicode: false),
                    })
                .PrimaryKey(t => t.PermissionId)
                .ForeignKey("dbo.WebBusiness", t => t.BusinessId, cascadeDelete: true)
                .Index(t => t.BusinessId);
            
            CreateTable(
                "dbo.WebBusiness",
                c => new
                    {
                        BusinessId = c.String(nullable: false, maxLength: 64, unicode: false),
                        BusinessName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.BusinessId);
            
            CreateTable(
                "dbo.WebCategory",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 256),
                        OrderNo = c.Int(nullable: false),
                        Status = c.String(maxLength: 32),
                        UserId = c.Guid(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.WebAdministrator", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WebPost",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 512),
                        Brief = c.String(nullable: false, maxLength: 1024),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        Picture = c.String(maxLength: 256),
                        CreateDate = c.DateTime(),
                        Tags = c.String(maxLength: 128),
                        CategoryId = c.Int(nullable: false),
                        ViewNo = c.Int(),
                        Status = c.String(maxLength: 32),
                        UserId = c.Guid(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.WebAdministrator", t => t.UserId)
                .ForeignKey("dbo.WebCategory", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 256),
                        ParentId = c.Int(),
                        LeaderId = c.Guid(),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Employee", t => t.LeaderId)
                .ForeignKey("dbo.Department", t => t.ParentId)
                .Index(t => t.ParentId)
                .Index(t => t.LeaderId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Guid(nullable: false, identity: true),
                        EmployeeCode = c.String(nullable: false, maxLength: 8, unicode: false),
                        EmployeeName = c.String(nullable: false, maxLength: 256),
                        DateOfBirth = c.DateTime(nullable: false),
                        IsMale = c.Byte(nullable: false),
                        IDCardNo = c.String(maxLength: 12),
                        DateOfIssue = c.DateTime(nullable: false),
                        PlaceOfIssue = c.String(maxLength: 64),
                        PermanentAddress = c.String(),
                        CurrentAddress = c.String(),
                        PhoneNumber = c.String(maxLength: 11),
                        IsSingle = c.Byte(nullable: false),
                        UserId = c.Guid(),
                        PositionId = c.Int(),
                        DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Position", t => t.PositionId)
                .ForeignKey("dbo.WebAdministrator", t => t.UserId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.UserId)
                .Index(t => t.PositionId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        PositionCode = c.String(nullable: false, maxLength: 4),
                        PositionName = c.String(nullable: false, maxLength: 64),
                        AllowanceRate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PositionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Department", "ParentId", "dbo.Department");
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Employee", "UserId", "dbo.WebAdministrator");
            DropForeignKey("dbo.Employee", "PositionId", "dbo.Position");
            DropForeignKey("dbo.Department", "LeaderId", "dbo.Employee");
            DropForeignKey("dbo.WebPost", "CategoryId", "dbo.WebCategory");
            DropForeignKey("dbo.WebPost", "UserId", "dbo.WebAdministrator");
            DropForeignKey("dbo.WebCategory", "UserId", "dbo.WebAdministrator");
            DropForeignKey("dbo.WebGrantPermission", "PermissionId", "dbo.WebPermission");
            DropForeignKey("dbo.WebPermission", "BusinessId", "dbo.WebBusiness");
            DropForeignKey("dbo.WebGrantPermission", "UserId", "dbo.WebAdministrator");
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropIndex("dbo.Employee", new[] { "PositionId" });
            DropIndex("dbo.Employee", new[] { "UserId" });
            DropIndex("dbo.Department", new[] { "LeaderId" });
            DropIndex("dbo.Department", new[] { "ParentId" });
            DropIndex("dbo.WebPost", new[] { "UserId" });
            DropIndex("dbo.WebPost", new[] { "CategoryId" });
            DropIndex("dbo.WebCategory", new[] { "UserId" });
            DropIndex("dbo.WebPermission", new[] { "BusinessId" });
            DropIndex("dbo.WebGrantPermission", new[] { "UserId" });
            DropIndex("dbo.WebGrantPermission", new[] { "PermissionId" });
            DropTable("dbo.Position");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
            DropTable("dbo.WebPost");
            DropTable("dbo.WebCategory");
            DropTable("dbo.WebBusiness");
            DropTable("dbo.WebPermission");
            DropTable("dbo.WebGrantPermission");
            DropTable("dbo.WebAdministrator");
        }
    }
}
