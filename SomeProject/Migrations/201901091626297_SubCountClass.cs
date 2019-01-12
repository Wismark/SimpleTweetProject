namespace SomeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubCountClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubListItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubId = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubListItems", "User_Id", "dbo.Users");
            DropIndex("dbo.SubListItems", new[] { "User_Id" });
            DropTable("dbo.SubListItems");
        }
    }
}
