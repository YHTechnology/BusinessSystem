namespace QuoteSystem.Migration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        ActionID = c.Int(nullable: false, identity: true),
                        ActionName = c.String(unicode: false),
                        SupperActionID = c.Int(),
                    })
                .PrimaryKey(t => t.ActionID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Long(nullable: false, identity: true),
                        ClientName = c.String(unicode: false),
                        CountryDomain = c.String(unicode: false),
                        ContactPerson = c.String(unicode: false),
                        ContactWay = c.String(unicode: false),
                        Duties = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ClientID);
            
            CreateTable(
                "dbo.ComponentMateriels",
                c => new
                    {
                        ComponentMaterielsID = c.Long(nullable: false, identity: true),
                        MeterielsCount = c.Int(nullable: false),
                        Meteriel_MaterielID = c.String(maxLength: 128, storeType: "nvarchar"),
                        Component_ComponentID = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ComponentMaterielsID)
                .ForeignKey("dbo.Materiels", t => t.Meteriel_MaterielID)
                .ForeignKey("dbo.Components", t => t.Component_ComponentID)
                .Index(t => t.Meteriel_MaterielID)
                .Index(t => t.Component_ComponentID);
            
            CreateTable(
                "dbo.Materiels",
                c => new
                    {
                        MaterielID = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        MaterielName = c.String(unicode: false),
                        MaterielSearchName = c.String(unicode: false),
                        MeterieDescription = c.String(unicode: false),
                        Unit = c.String(unicode: false),
                        Brand = c.String(unicode: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MaterielID);
            
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        ComponentID = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ComponentName = c.String(unicode: false),
                        ComponentSearchName = c.String(unicode: false),
                        Unit = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ComponentID);
            
            CreateTable(
                "dbo.TechnicalProtocols",
                c => new
                    {
                        TechnicalProtocolID = c.Long(nullable: false, identity: true),
                        Language = c.String(unicode: false),
                        TechnicalProtocolDetail = c.String(unicode: false),
                        Component_ComponentID = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.TechnicalProtocolID)
                .ForeignKey("dbo.Components", t => t.Component_ComponentID)
                .Index(t => t.Component_ComponentID);
            
            CreateTable(
                "dbo.WorkingDrawings",
                c => new
                    {
                        WorkingDrawingID = c.Long(nullable: false, identity: true),
                        WorkingDrawingName = c.String(unicode: false),
                        WorkingDrawingFileName = c.String(unicode: false),
                        Component_ComponentID = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.WorkingDrawingID)
                .ForeignKey("dbo.Components", t => t.Component_ComponentID)
                .Index(t => t.Component_ComponentID);
            
            CreateTable(
                "dbo.DepartmentActions",
                c => new
                    {
                        DepartmentActionID = c.Long(nullable: false, identity: true),
                        IsPermit = c.Boolean(),
                        Action_ActionID = c.Int(),
                        Component_ComponentID = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.DepartmentActionID)
                .ForeignKey("dbo.Actions", t => t.Action_ActionID)
                .ForeignKey("dbo.Components", t => t.Component_ComponentID)
                .Index(t => t.Action_ActionID)
                .Index(t => t.Component_ComponentID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentName = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.DepartmentName);
            
            CreateTable(
                "dbo.OriginalFiles",
                c => new
                    {
                        OriginalFileID = c.Long(nullable: false, identity: true),
                        OriginalFileName = c.String(unicode: false),
                        OriginalFileFileName = c.String(unicode: false),
                        Project_ProjectID = c.Long(),
                    })
                .PrimaryKey(t => t.OriginalFileID)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectID)
                .Index(t => t.Project_ProjectID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectID = c.Long(nullable: false, identity: true),
                        ProjectName = c.String(unicode: false),
                        Describe = c.String(unicode: false),
                        TechnologyDescribe = c.String(unicode: false),
                        BusinessCreateUser = c.String(unicode: false),
                        BusinessCreateDateTime = c.DateTime(precision: 0),
                        QuoteDateTime = c.DateTime(precision: 0),
                        ProjectStatus = c.Int(nullable: false),
                        Client_ClientID = c.Long(),
                    })
                .PrimaryKey(t => t.ProjectID)
                .ForeignKey("dbo.Clients", t => t.Client_ClientID)
                .Index(t => t.Client_ClientID);
            
            CreateTable(
                "dbo.TechnicalProposalComponents",
                c => new
                    {
                        ProposalComponentID = c.Long(nullable: false, identity: true),
                        ComponentCount = c.Int(nullable: false),
                        TPID = c.Long(nullable: false),
                        Component_ComponentID = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ProposalComponentID)
                .ForeignKey("dbo.Components", t => t.Component_ComponentID)
                .ForeignKey("dbo.TechnicalProposals", t => t.TPID, cascadeDelete: true)
                .Index(t => t.TPID)
                .Index(t => t.Component_ComponentID);
            
            CreateTable(
                "dbo.TechnicalProposals",
                c => new
                    {
                        TechnicalProposalID = c.Long(nullable: false, identity: true),
                        TechnicalProposalName = c.String(unicode: false),
                        TechnicalProposalVersion = c.String(unicode: false),
                        TechnologyDesignUser = c.String(unicode: false),
                        TechnologyDesignDateTime = c.DateTime(precision: 0),
                        TechnologyVerifyUser = c.String(unicode: false),
                        TechnologyVerifyDateTime = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.TechnicalProposalID);
            
            CreateTable(
                "dbo.UserActions",
                c => new
                    {
                        UserActionID = c.Long(nullable: false, identity: true),
                        IsPermit = c.Boolean(nullable: false),
                        Action_ActionID = c.Int(),
                        User_UserName = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.UserActionID)
                .ForeignKey("dbo.Actions", t => t.Action_ActionID)
                .ForeignKey("dbo.Users", t => t.User_UserName)
                .Index(t => t.Action_ActionID)
                .Index(t => t.User_UserName);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserCName = c.String(unicode: false),
                        Department = c.String(unicode: false),
                        Group = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserActions", "User_UserName", "dbo.Users");
            DropForeignKey("dbo.UserActions", "Action_ActionID", "dbo.Actions");
            DropForeignKey("dbo.TechnicalProposalComponents", "TPID", "dbo.TechnicalProposals");
            DropForeignKey("dbo.TechnicalProposalComponents", "Component_ComponentID", "dbo.Components");
            DropForeignKey("dbo.OriginalFiles", "Project_ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "Client_ClientID", "dbo.Clients");
            DropForeignKey("dbo.DepartmentActions", "Component_ComponentID", "dbo.Components");
            DropForeignKey("dbo.DepartmentActions", "Action_ActionID", "dbo.Actions");
            DropForeignKey("dbo.WorkingDrawings", "Component_ComponentID", "dbo.Components");
            DropForeignKey("dbo.TechnicalProtocols", "Component_ComponentID", "dbo.Components");
            DropForeignKey("dbo.ComponentMateriels", "Component_ComponentID", "dbo.Components");
            DropForeignKey("dbo.ComponentMateriels", "Meteriel_MaterielID", "dbo.Materiels");
            DropIndex("dbo.UserActions", new[] { "User_UserName" });
            DropIndex("dbo.UserActions", new[] { "Action_ActionID" });
            DropIndex("dbo.TechnicalProposalComponents", new[] { "Component_ComponentID" });
            DropIndex("dbo.TechnicalProposalComponents", new[] { "TPID" });
            DropIndex("dbo.Projects", new[] { "Client_ClientID" });
            DropIndex("dbo.OriginalFiles", new[] { "Project_ProjectID" });
            DropIndex("dbo.DepartmentActions", new[] { "Component_ComponentID" });
            DropIndex("dbo.DepartmentActions", new[] { "Action_ActionID" });
            DropIndex("dbo.WorkingDrawings", new[] { "Component_ComponentID" });
            DropIndex("dbo.TechnicalProtocols", new[] { "Component_ComponentID" });
            DropIndex("dbo.ComponentMateriels", new[] { "Component_ComponentID" });
            DropIndex("dbo.ComponentMateriels", new[] { "Meteriel_MaterielID" });
            DropTable("dbo.Users");
            DropTable("dbo.UserActions");
            DropTable("dbo.TechnicalProposals");
            DropTable("dbo.TechnicalProposalComponents");
            DropTable("dbo.Projects");
            DropTable("dbo.OriginalFiles");
            DropTable("dbo.Departments");
            DropTable("dbo.DepartmentActions");
            DropTable("dbo.WorkingDrawings");
            DropTable("dbo.TechnicalProtocols");
            DropTable("dbo.Components");
            DropTable("dbo.Materiels");
            DropTable("dbo.ComponentMateriels");
            DropTable("dbo.Clients");
            DropTable("dbo.Actions");
        }
    }
}
