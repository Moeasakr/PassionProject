namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statistics_update_4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Statistics", "NumberOfPairs", c => c.Int(nullable: false));
            AddColumn("dbo.Statistics", "NumberOfFailedPairs", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Statistics", "NumberOfFailedPairs");
            DropColumn("dbo.Statistics", "NumberOfPairs");
        }
    }
}
