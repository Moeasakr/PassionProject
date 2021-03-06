namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statistics_update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Statistics", "Visibility");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Statistics", "Visibility", c => c.Boolean(nullable: false));
        }
    }
}
