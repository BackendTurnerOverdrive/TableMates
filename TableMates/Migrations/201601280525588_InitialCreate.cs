namespace TableMates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Lat = c.Single(nullable: false),
                        Lng = c.Single(nullable: false),
                        MinAttendees = c.Int(nullable: false),
                        MaxAttendees = c.Int(),
                        AppointmentName = c.String(nullable: false),
                        RestaurantName = c.String(),
                        AppointmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        username = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserAppointment",
                c => new
                    {
                        User_ID = c.Int(nullable: false),
                        Appointment_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_ID, t.Appointment_ID })
                .ForeignKey("dbo.User", t => t.User_ID, cascadeDelete: true)
                .ForeignKey("dbo.Appointment", t => t.Appointment_ID, cascadeDelete: true)
                .Index(t => t.User_ID)
                .Index(t => t.Appointment_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAppointment", "Appointment_ID", "dbo.Appointment");
            DropForeignKey("dbo.UserAppointment", "User_ID", "dbo.User");
            DropIndex("dbo.UserAppointment", new[] { "Appointment_ID" });
            DropIndex("dbo.UserAppointment", new[] { "User_ID" });
            DropTable("dbo.UserAppointment");
            DropTable("dbo.User");
            DropTable("dbo.Appointment");
        }
    }
}
