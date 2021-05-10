namespace SMPerformance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ScrumTeam", "TeamName", c => c.String(nullable: false));
            DropColumn("dbo.ScrumTeam", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ScrumTeam", "Name", c => c.String(nullable: false));
            DropColumn("dbo.ScrumTeam", "TeamName");
        }
    }
}
