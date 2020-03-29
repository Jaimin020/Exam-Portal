namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Papers", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.Papers", new[] { "Subject_Id" });
            AlterColumn("dbo.Papers", "Subject_Id", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Papers", "Subject_Id", c => c.Int());
            CreateIndex("dbo.Papers", "Subject_Id");
            AddForeignKey("dbo.Papers", "Subject_Id", "dbo.Subjects", "Id");
        }
    }
}
