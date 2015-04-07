namespace QuoteSystem.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtechuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "TechnologyUser", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "TechnologyUser");
        }
    }
}
