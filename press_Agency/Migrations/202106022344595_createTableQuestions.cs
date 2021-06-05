namespace press_Agency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createTableQuestions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        editor_name = c.String(),
                        Qusetions = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Questions");
        }
    }
}
