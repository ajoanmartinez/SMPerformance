namespace SMPerformance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OnwnerIDMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScrumMaster", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.TeamMetric", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.ScrumTeam", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ScrumTeam", "OwnerId");
            DropColumn("dbo.TeamMetric", "OwnerId");
            DropColumn("dbo.ScrumMaster", "OwnerId");
        }
    }
}
