namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAtendance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "Attendee_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "CourseID" });
            DropIndex("dbo.Attendances", new[] { "Attendee_Id" });
            DropPrimaryKey("dbo.Attendances");
            AddColumn("dbo.Attendances", "AttendanceId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Attendances", new[] { "CourseId", "AttendanceId" });
            CreateIndex("dbo.Attendances", "CourseId");
            DropColumn("dbo.Attendances", "AttendeeID");
            DropColumn("dbo.Attendances", "Attendee_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "Attendee_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Attendances", "AttendeeID", c => c.Int(nullable: false));
            DropIndex("dbo.Attendances", new[] { "CourseId" });
            DropPrimaryKey("dbo.Attendances");
            DropColumn("dbo.Attendances", "AttendanceId");
            AddPrimaryKey("dbo.Attendances", new[] { "CourseID", "AttendeeID" });
            CreateIndex("dbo.Attendances", "Attendee_Id");
            CreateIndex("dbo.Attendances", "CourseID");
            AddForeignKey("dbo.Attendances", "Attendee_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
