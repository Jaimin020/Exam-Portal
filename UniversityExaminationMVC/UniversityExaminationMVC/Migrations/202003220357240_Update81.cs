namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update81 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Papers", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.Papers", new[] { "Subject_Id" });
            AlterColumn("dbo.Papers", "Subject_Id", c => c.Int());
            CreateIndex("dbo.Papers", "Subject_Id");
            AddForeignKey("dbo.Papers", "Subject_Id", "dbo.Subjects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Papers", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.Papers", new[] { "Subject_Id" });
            AlterColumn("dbo.Papers", "Subject_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Papers", "Subject_Id");
            AddForeignKey("dbo.Papers", "Subject_Id", "dbo.Subjects", "Id", cascadeDelete: true);
        }
    }
}
