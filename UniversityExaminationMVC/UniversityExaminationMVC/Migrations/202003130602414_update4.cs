namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Marks = c.Int(nullable: false),
                        Hint = c.String(),
                        isPublic = c.Boolean(nullable: false),
                        Faculty_Id = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Faculties", t => t.Faculty_Id)
                .Index(t => t.Faculty_Id);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        OptionsId = c.Int(nullable: false, identity: true),
                        ans = c.String(nullable: false),
                        isAnswer = c.Boolean(nullable: false),
                        Question_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.OptionsId)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId)
                .Index(t => t.Question_QuestionId);
            
            CreateTable(
                "dbo.PaperQuestions",
                c => new
                    {
                        PaperId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PaperId, t.QuestionId })
                .ForeignKey("dbo.Papers", t => t.PaperId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.PaperId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Papers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        paperDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        isPublic = c.Boolean(nullable: false),
                        FacultyProfileId = c.Int(nullable: false),
                        exam_Exam_Id = c.Int(),
                        Subject_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.exam_Exam_Id)
                .ForeignKey("dbo.Faculties", t => t.FacultyProfileId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .Index(t => t.FacultyProfileId)
                .Index(t => t.exam_Exam_Id)
                .Index(t => t.Subject_Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Sem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Faculty_Id", "dbo.Faculties");
            DropForeignKey("dbo.PaperQuestions", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Papers", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.PaperQuestions", "PaperId", "dbo.Papers");
            DropForeignKey("dbo.Papers", "FacultyProfileId", "dbo.Faculties");
            DropForeignKey("dbo.Papers", "exam_Exam_Id", "dbo.Exams");
            DropForeignKey("dbo.Options", "Question_QuestionId", "dbo.Questions");
            DropIndex("dbo.Papers", new[] { "Subject_Id" });
            DropIndex("dbo.Papers", new[] { "exam_Exam_Id" });
            DropIndex("dbo.Papers", new[] { "FacultyProfileId" });
            DropIndex("dbo.PaperQuestions", new[] { "QuestionId" });
            DropIndex("dbo.PaperQuestions", new[] { "PaperId" });
            DropIndex("dbo.Options", new[] { "Question_QuestionId" });
            DropIndex("dbo.Questions", new[] { "Faculty_Id" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Papers");
            DropTable("dbo.PaperQuestions");
            DropTable("dbo.Options");
            DropTable("dbo.Questions");
        }
    }
}
