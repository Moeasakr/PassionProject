namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statistics_update_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Statistics", "AlphabetID", c => c.Int(nullable: false));
            AlterColumn("dbo.Statistics", "Status", c => c.Int(nullable: false));
            CreateIndex("dbo.Statistics", "AlphabetID");
            AddForeignKey("dbo.Statistics", "AlphabetID", "dbo.Alphabets", "AlphabetID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Statistics", "AlphabetID", "dbo.Alphabets");
            DropIndex("dbo.Statistics", new[] { "AlphabetID" });
            AlterColumn("dbo.Statistics", "Status", c => c.String());
            DropColumn("dbo.Statistics", "AlphabetID");
        }
    }
}
