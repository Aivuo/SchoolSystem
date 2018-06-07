namespace SchoolSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiddleNameTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "MiddleName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "MiddleName");
        }
    }
}
