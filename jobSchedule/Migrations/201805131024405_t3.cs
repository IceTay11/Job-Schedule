namespace jobSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "lifeguardID", c => c.Int(nullable: false));
            CreateIndex("dbo.Schedules", "lifeguardID");
            AddForeignKey("dbo.Schedules", "lifeguardID", "dbo.Lifeguards", "lifeguardID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "lifeguardID", "dbo.Lifeguards");
            DropIndex("dbo.Schedules", new[] { "lifeguardID" });
            DropColumn("dbo.Schedules", "lifeguardID");
        }
    }
}
