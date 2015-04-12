namespace QuoteSystem.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatebstask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BSTasks", "CreateTaskUser", c => c.String(unicode: false));
            DropColumn("dbo.BSTasks", "CreatTaskUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BSTasks", "CreatTaskUser", c => c.String(unicode: false));
            DropColumn("dbo.BSTasks", "CreateTaskUser");
        }
    }
}
