namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "date", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exams", "date");
        }
    }
}
