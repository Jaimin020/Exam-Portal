namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Papers", "FacultyProfileId", "dbo.Faculties");
            DropIndex("dbo.Papers", new[] { "FacultyProfileId" });
            RenameColumn(table: "dbo.Papers", name: "FacultyProfileId", newName: "Faculty_Id");
            AlterColumn("dbo.Papers", "Faculty_Id", c => c.Int());
            CreateIndex("dbo.Papers", "Faculty_Id");
            AddForeignKey("dbo.Papers", "Faculty_Id", "dbo.Faculties", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Papers", "Faculty_Id", "dbo.Faculties");
            DropIndex("dbo.Papers", new[] { "Faculty_Id" });
            AlterColumn("dbo.Papers", "Faculty_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Papers", name: "Faculty_Id", newName: "FacultyProfileId");
            CreateIndex("dbo.Papers", "FacultyProfileId");
            AddForeignKey("dbo.Papers", "FacultyProfileId", "dbo.Faculties", "Id", cascadeDelete: true);
        }
    }
}
