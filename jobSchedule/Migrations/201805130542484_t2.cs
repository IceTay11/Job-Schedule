namespace jobSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Schedules", "city_id", "dbo.Cities");
            DropIndex("dbo.Schedules", new[] { "city_id" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Schedules", "city_id");
            AddForeignKey("dbo.Schedules", "city_id", "dbo.Cities", "city_id");
        }
    }
}
