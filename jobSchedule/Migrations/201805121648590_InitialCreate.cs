namespace jobSchedule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beaches",
                c => new
                    {
                        beachID = c.Int(nullable: false, identity: true),
                        beachName = c.String(nullable: false),
                        city_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.beachID)
                .ForeignKey("dbo.Cities", t => t.city_id)
                .Index(t => t.city_id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        city_id = c.Int(nullable: false, identity: true),
                        city_name = c.String(nullable: false),
                        province = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.city_id);
            
            CreateTable(
                "dbo.Lifeguards",
                c => new
                    {
                        lifeguardID = c.Int(nullable: false, identity: true),
                        Lifeguard_Name = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        gender = c.String(nullable: false),
                        city_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.lifeguardID)
                .ForeignKey("dbo.Cities", t => t.city_id)
                .Index(t => t.city_id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        scheduleID = c.Int(nullable: false, identity: true),
                        dutyStart = c.DateTime(nullable: false),
                        dutyEnd = c.DateTime(nullable: false),
                        city_id = c.Int(nullable: false),
                        beachID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.scheduleID)
                .ForeignKey("dbo.Beaches", t => t.beachID)
                .ForeignKey("dbo.Cities", t => t.city_id)
                .Index(t => t.city_id)
                .Index(t => t.beachID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "city_id", "dbo.Cities");
            DropForeignKey("dbo.Schedules", "beachID", "dbo.Beaches");
            DropForeignKey("dbo.Lifeguards", "city_id", "dbo.Cities");
            DropForeignKey("dbo.Beaches", "city_id", "dbo.Cities");
            DropIndex("dbo.Schedules", new[] { "beachID" });
            DropIndex("dbo.Schedules", new[] { "city_id" });
            DropIndex("dbo.Lifeguards", new[] { "city_id" });
            DropIndex("dbo.Beaches", new[] { "city_id" });
            DropTable("dbo.Schedules");
            DropTable("dbo.Lifeguards");
            DropTable("dbo.Cities");
            DropTable("dbo.Beaches");
        }
    }
}
