namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update5 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Questions", new[] { "Faculty_Id" });
            CreateIndex("dbo.Questions", "faculty_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Questions", new[] { "faculty_Id" });
            CreateIndex("dbo.Questions", "Faculty_Id");
        }
    }
}
