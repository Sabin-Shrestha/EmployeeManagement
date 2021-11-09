namespace EmployeeManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class departmen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentViewModels",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        DepartmentNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            AddColumn("dbo.EmployeeViewModels", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeViewModels", "DepartmentId");
            AddForeignKey("dbo.EmployeeViewModels", "DepartmentId", "dbo.DepartmentViewModels", "DepartmentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeViewModels", "DepartmentId", "dbo.DepartmentViewModels");
            DropIndex("dbo.EmployeeViewModels", new[] { "DepartmentId" });
            DropColumn("dbo.EmployeeViewModels", "DepartmentId");
            DropTable("dbo.DepartmentViewModels");
        }
    }
}
