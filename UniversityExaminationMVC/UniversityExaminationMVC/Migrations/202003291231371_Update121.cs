namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update121 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExamPapers",
                c => new
                    {
                        ExamId = c.Int(nullable: false),
                        PaperId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExamId, t.PaperId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExamPapers");
        }
    }
}
