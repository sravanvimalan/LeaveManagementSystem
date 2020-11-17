namespace LeaveManagementSystem.DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimenullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Experience", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Experience", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Experience", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Experience", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
