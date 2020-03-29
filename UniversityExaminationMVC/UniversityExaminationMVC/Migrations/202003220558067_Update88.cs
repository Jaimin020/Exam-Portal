namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update88 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Questions", "isPublic");
        }
        
        public override void Down()
        {
            
        }
    }
}
