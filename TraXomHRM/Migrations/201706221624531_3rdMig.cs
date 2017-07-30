namespace TraXomHRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3rdMig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WebPost", "UserId", "dbo.WebAdministrator");
            DropIndex("dbo.WebPost", new[] { "UserId" });
            AlterColumn("dbo.WebAdministrator", "IsAdmin", c => c.Boolean(nullable: false));
            AlterColumn("dbo.WebAdministrator", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.WebPost", "CreateDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.WebPost", "ViewNo", c => c.Int(nullable: false));
            AlterColumn("dbo.WebPost", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.WebPost", "UserId");
            AddForeignKey("dbo.WebPost", "UserId", "dbo.WebAdministrator", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WebPost", "UserId", "dbo.WebAdministrator");
            DropIndex("dbo.WebPost", new[] { "UserId" });
            AlterColumn("dbo.WebPost", "UserId", c => c.Guid());
            AlterColumn("dbo.WebPost", "ViewNo", c => c.Int());
            AlterColumn("dbo.WebPost", "CreateDate", c => c.DateTime());
            AlterColumn("dbo.WebAdministrator", "IsActive", c => c.Boolean());
            AlterColumn("dbo.WebAdministrator", "IsAdmin", c => c.Boolean());
            CreateIndex("dbo.WebPost", "UserId");
            AddForeignKey("dbo.WebPost", "UserId", "dbo.WebAdministrator", "UserId");
        }
    }
}
