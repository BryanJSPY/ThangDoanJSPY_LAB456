namespace doanchithang_lab456_1711061719.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AiBiet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "CourseId", "dbo.Courses");
            AddForeignKey("dbo.Attendances", "CourseId", "dbo.Courses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "CourseId", "dbo.Courses");
            AddForeignKey("dbo.Attendances", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
