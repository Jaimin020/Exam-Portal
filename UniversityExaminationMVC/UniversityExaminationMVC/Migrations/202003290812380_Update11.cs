namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String());
            AlterColumn("dbo.Students", "DOB", c => c.String());
            AlterColumn("dbo.Students", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "DOB", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false));
        }
    }
}
