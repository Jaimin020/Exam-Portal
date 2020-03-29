namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Options", "Question_QuestionId", "dbo.Questions");
            DropIndex("dbo.Options", new[] { "Question_QuestionId" });
            AddColumn("dbo.Questions", "Answer", c => c.String());
            DropTable("dbo.Options");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        OptionsId = c.Int(nullable: false, identity: true),
                        ans = c.String(nullable: false),
                        isAnswer = c.Boolean(nullable: false),
                        Question_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.OptionsId);
            
            DropColumn("dbo.Questions", "Answer");
            CreateIndex("dbo.Options", "Question_QuestionId");
            AddForeignKey("dbo.Options", "Question_QuestionId", "dbo.Questions", "QuestionId");
        }
    }
}
