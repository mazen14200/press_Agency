namespace press_Agency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createTableQuestions1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.posts", "num_of_likes", c => c.Int(nullable: false));
            AddColumn("dbo.posts", "num_of_dislikes", c => c.Int(nullable: false));
            AddColumn("dbo.posts", "post_status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.posts", "post_status");
            DropColumn("dbo.posts", "num_of_dislikes");
            DropColumn("dbo.posts", "num_of_likes");
        }
    }
}
