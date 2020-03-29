namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update87 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Questions", new[] { "Faculty_Id" });
            CreateIndex("dbo.Questions", "faculty_Id");
            DropColumn("dbo.Questions", "faculty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "faculty", c => c.Int(nullable: false));
            DropIndex("dbo.Questions", new[] { "faculty_Id" });
            CreateIndex("dbo.Questions", "Faculty_Id");
        }
    }
}
