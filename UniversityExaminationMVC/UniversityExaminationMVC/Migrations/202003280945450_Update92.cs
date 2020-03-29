namespace UniversityExaminationMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update92 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Papers", "paperDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Papers", "paperDate", c => c.DateTime(nullable: false));
        }
    }
}
