namespace SomeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestModel1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tweets", "Author_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tweets", "Author_id", c => c.Int(nullable: false));
        }
    }
}
