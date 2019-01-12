namespace SomeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestModel3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tweets", "Author_id", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tweets", "Author_id");
        }
    }
}
