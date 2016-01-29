namespace TableMates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAppointment", "User_ID", "dbo.User");
            DropForeignKey("dbo.UserAppointment", "Appointment_ID", "dbo.Appointment");
            DropIndex("dbo.UserAppointment", new[] { "User_ID" });
            DropIndex("dbo.UserAppointment", new[] { "Appointment_ID" });
            DropPrimaryKey("dbo.User");
            AddColumn("dbo.Appointment", "User_username", c => c.String(maxLength: 128));
            AlterColumn("dbo.User", "username", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.User", "username");
            CreateIndex("dbo.Appointment", "User_username");
            AddForeignKey("dbo.Appointment", "User_username", "dbo.User", "username");
            DropColumn("dbo.User", "ID");
            DropTable("dbo.UserAppointment");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserAppointment",
                c => new
                    {
                        User_ID = c.Int(nullable: false),
                        Appointment_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_ID, t.Appointment_ID });
            
            AddColumn("dbo.User", "ID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Appointment", "User_username", "dbo.User");
            DropIndex("dbo.Appointment", new[] { "User_username" });
            DropPrimaryKey("dbo.User");
            AlterColumn("dbo.User", "username", c => c.String());
            DropColumn("dbo.Appointment", "User_username");
            AddPrimaryKey("dbo.User", "ID");
            CreateIndex("dbo.UserAppointment", "Appointment_ID");
            CreateIndex("dbo.UserAppointment", "User_ID");
            AddForeignKey("dbo.UserAppointment", "Appointment_ID", "dbo.Appointment", "ID", cascadeDelete: true);
            AddForeignKey("dbo.UserAppointment", "User_ID", "dbo.User", "ID", cascadeDelete: true);
        }
    }
}
