namespace press_Agency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createTableSavedPosts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Savedposts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        user_name = c.String(),
                        artical_Title = c.String(),
                        artical_Body = c.String(maxLength: 2000),
                        postCreationDate = c.DateTime(nullable: false),
                        artical_Type = c.String(),
                        NumberOfViewers = c.Int(),
                        artical_image = c.String(maxLength: 2000),
                        editor_name = c.String(),
                        post_status = c.String(),
                        num_of_likes = c.Int(nullable: false),
                        num_of_dislikes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Savedposts");
        }
    }
}
