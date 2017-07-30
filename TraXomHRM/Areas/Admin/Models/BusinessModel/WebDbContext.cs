using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TraXomHRM.Areas.Admin.Models.DataModel;

namespace TraXomHRM.Areas.Admin.Models.BusinessModel
{
    public class WebDbContext : DbContext
    {
        public WebDbContext() : base("name = WebDbContextConnectString")
        {

        }
        public DbSet<WebAdministrator> Administrators { get; set; }
        public DbSet<WebBusiness> Businesses { get; set; }
        public DbSet<WebCategory> Categories { get; set; }
        public DbSet<WebGrantPermission> GrantPermissions { get; set; }
        public DbSet<WebPermission> Permissions { get; set; }
        public DbSet<WebPost> Posts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}