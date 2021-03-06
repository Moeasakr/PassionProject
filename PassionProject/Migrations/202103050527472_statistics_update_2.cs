namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statistics_update_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Statistics", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Statistics", "UserID", c => c.Int(nullable: false));
        }
    }
}
