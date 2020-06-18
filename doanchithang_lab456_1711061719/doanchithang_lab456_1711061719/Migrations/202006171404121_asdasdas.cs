namespace doanchithang_lab456_1711061719.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdasdas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "IsCanceled");
        }
    }
}
