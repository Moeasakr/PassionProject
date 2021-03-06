namespace PassionProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_settings_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSettings",
                c => new
                    {
                        SettingID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        LowSuccessRate = c.Int(nullable: false),
                        NumberOfPairs = c.Int(nullable: false),
                        HiraganaLetters = c.String(),
                    })
                .PrimaryKey(t => t.SettingID);
            
            DropTable("dbo.Settings");
        }
        
        public override void Down()
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
            
            DropTable("dbo.UserSettings");
        }
    }
}
