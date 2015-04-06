namespace QuoteSystem.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventAndTask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BSEvents",
                c => new
                    {
                        BSEventID = c.Long(nullable: false, identity: true),
                        TaskID = c.Long(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        EventUser = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.BSEventID);
            
            CreateTable(
                "dbo.BSTasks",
                c => new
                    {
                        BSTaskID = c.Long(nullable: false, identity: true),
                        TaskType = c.Int(nullable: false),
                        TaskUser = c.String(unicode: false),
                        TaskCUser = c.String(unicode: false),
                        CreatTaskUser = c.String(unicode: false),
                        CreateTaskCUser = c.String(unicode: false),
                        TaskStatus = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false, precision: 0),
                        FinishDateTime = c.DateTime(nullable: false, precision: 0),
                        TaskName = c.String(unicode: false),
                        TaskDescribe = c.String(unicode: false),
                        TaskContext = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.BSTaskID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BSTasks");
            DropTable("dbo.BSEvents");
        }
    }
}
