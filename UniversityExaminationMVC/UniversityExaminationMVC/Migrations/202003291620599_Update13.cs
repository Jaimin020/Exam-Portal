namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaperScores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marks = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                        Paper_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaperScores");
        }
    }
}
