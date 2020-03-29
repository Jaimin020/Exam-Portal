namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update86 : DbMigration
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
                        Subject_Id = c.Int(),

                })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.Faculties", t => t.Faculty_Id)
                .Index(t => t.Faculty_Id);
            
        }
        
        public override void Down()
        {
        }
    }
}
