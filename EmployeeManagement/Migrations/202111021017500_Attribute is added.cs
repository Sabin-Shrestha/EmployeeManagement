namespace EmployeeManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Attributeisadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        ContactNo = c.Int(nullable: false),
                        Email = c.String(),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Employees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.EmployeeViewModels");
        }
    }
}
