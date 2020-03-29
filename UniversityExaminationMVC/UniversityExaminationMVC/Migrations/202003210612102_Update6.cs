namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Branch_Branch_Id", c => c.Int());
            CreateIndex("dbo.Students", "Branch_Branch_Id");
            AddForeignKey("dbo.Students", "Branch_Branch_Id", "dbo.Branches", "Branch_Id");
            DropColumn("dbo.Students", "Branch");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Branch", c => c.String(nullable: false));
            DropForeignKey("dbo.Students", "Branch_Branch_Id", "dbo.Branches");
            DropIndex("dbo.Students", new[] { "Branch_Branch_Id" });
            DropColumn("dbo.Students", "Branch_Branch_Id");
        }
    }
}
