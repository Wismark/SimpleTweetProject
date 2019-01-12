namespace SomeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SubListItems", new[] { "User_Id" });
            AddColumn("dbo.Tweets", "User_Id", c => c.Int());
            AddColumn("dbo.Users", "User_Id", c => c.Int());
            CreateIndex("dbo.Tweets", "User_Id");
            CreateIndex("dbo.Users", "User_Id");
            AddForeignKey("dbo.Tweets", "User_Id", "dbo.Users", "Id");
            DropTable("dbo.SubListItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubListItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubId = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Tweets", "User_Id", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_Id" });
            DropIndex("dbo.Tweets", new[] { "User_Id" });
            DropColumn("dbo.Users", "User_Id");
            DropColumn("dbo.Tweets", "User_Id");
            CreateIndex("dbo.SubListItems", "User_Id");
        }
    }
}
