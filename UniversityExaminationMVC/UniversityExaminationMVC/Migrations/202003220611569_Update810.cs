namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update810 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "Subject_Id", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "Subject_Id", c => c.Int(nullable: false));
        }
    }
}
