namespace EmployeeManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeViewModels", "ContactNo", c => c.String());
            DropColumn("dbo.EmployeeViewModels", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeViewModels", "Gender", c => c.String());
            AlterColumn("dbo.EmployeeViewModels", "ContactNo", c => c.Int(nullable: false));
        }
    }
}
