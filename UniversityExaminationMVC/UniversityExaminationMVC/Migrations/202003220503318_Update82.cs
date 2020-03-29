namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update82 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Subject_Id", c => c.Int());
            CreateIndex("dbo.Questions", "Subject_Id");
            AddForeignKey("dbo.Questions", "Subject_Id", "dbo.Subjects", "Id");
            DropColumn("dbo.Questions", "isPublic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "isPublic", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Questions", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.Questions", new[] { "Subject_Id" });
            DropColumn("dbo.Questions", "Subject_Id");
        }
    }
}
