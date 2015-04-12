namespace QuoteSystem.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtechcname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "TechnologyUserCName", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "TechnologyUserCName");
        }
    }
}
