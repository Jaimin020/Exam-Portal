namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update111 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faculties", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Faculties", "Name", c => c.String());
            AlterColumn("dbo.Faculties", "Branch", c => c.String());
            AlterColumn("dbo.Faculties", "EducationalQualifications", c => c.String());
            AlterColumn("dbo.Faculties", "DOB", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Faculties", "DOB", c => c.String(nullable: false));
            AlterColumn("dbo.Faculties", "EducationalQualifications", c => c.String(nullable: false));
            AlterColumn("dbo.Faculties", "Branch", c => c.String(nullable: false));
            AlterColumn("dbo.Faculties", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Faculties", "Password");
        }
    }
}
