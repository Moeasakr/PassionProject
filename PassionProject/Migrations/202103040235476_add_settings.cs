namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_settings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Setting = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        LowSuccessRate = c.Int(nullable: false),
                        NumberOfPairs = c.Int(nullable: false),
                        HiraganaLetters = c.String(),
                    })
                .PrimaryKey(t => t.Setting);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Settings");
        }
    }
}
