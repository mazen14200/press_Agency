namespace press_Agency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterTableQuestions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "username", c => c.String(nullable: false));
            AlterColumn("dbo.Questions", "editor_name", c => c.String(nullable: false));
            AlterColumn("dbo.Questions", "Qusetions", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "Qusetions", c => c.String());
            AlterColumn("dbo.Questions", "editor_name", c => c.String());
            AlterColumn("dbo.Questions", "username", c => c.String());
        }
    }
}
