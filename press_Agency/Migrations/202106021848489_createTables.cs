namespace press_Agency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.posts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        artical_Title = c.String(),
                        artical_Body = c.String(maxLength: 2000),
                        postCreationDate = c.DateTime(nullable: false),
                        artical_Type = c.String(),
                        NumberOfViewers = c.Int(),
                        artical_image = c.String(maxLength: 2000),
                        editor_username = c.String(),
                        editor_name_username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.users", t => t.editor_name_username)
                .Index(t => t.editor_name_username);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        username = c.String(nullable: false, maxLength: 128),
                        Fname = c.String(nullable: false),
                        Lname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        phoneNumber = c.String(nullable: false),
                        photo = c.String(maxLength: 2000),
                        userRole = c.String(),
                    })
                .PrimaryKey(t => t.username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.posts", "editor_name_username", "dbo.users");
            DropIndex("dbo.posts", new[] { "editor_name_username" });
            DropTable("dbo.users");
            DropTable("dbo.posts");
        }
    }
}
