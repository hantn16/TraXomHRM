namespace TraXomHRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2ndMig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WebAdministrator", "IsAdmin", c => c.Boolean());
            AlterColumn("dbo.WebAdministrator", "IsActive", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WebAdministrator", "IsActive", c => c.Byte());
            AlterColumn("dbo.WebAdministrator", "IsAdmin", c => c.Byte());
        }
    }
}
