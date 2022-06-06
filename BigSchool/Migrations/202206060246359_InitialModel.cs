namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "LectureId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "LectureId");
        }
    }
}
