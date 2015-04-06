using System.Data.Entity;

namespace QuoteSystem.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class BusnessSystemDBContext : DbContext
    {
        public BusnessSystemDBContext() : base("BusnessSystemDB")
        {

        }
        public DbSet<BS.Entities.Action> Actions { get; set; }
        public DbSet<BS.Entities.BSEvent> BSEvents { get; set; }
        public DbSet<BS.Entities.BSTask> BSTasks { get; set; }
        public DbSet<BS.Entities.Client> Client { get; set; }
        public DbSet<BS.Entities.Component> Components { get; set; }
        public DbSet<BS.Entities.ComponentMateriels> ComponentMateriels { get; set; }
        public DbSet<BS.Entities.Department> Departments { get; set; }
        public DbSet<BS.Entities.DepartmentAction> DepartmentActions { get; set; }
        public DbSet<BS.Entities.Materiel> Materiels { get; set; }
        public DbSet<BS.Entities.OriginalFile> OriginalFiles { get; set; }
        public DbSet<BS.Entities.Project> Projects { get; set; }
        public DbSet<BS.Entities.TechnicalProposal> TechnicalProposals { get; set; }
        public DbSet<BS.Entities.TechnicalProposalComponent> TechnicalProposalComponents { get; set; }
        public DbSet<BS.Entities.TechnicalProtocol> TechnicalProtocols { get; set; }
        public DbSet<BS.Entities.User> Users { get; set; }
        public DbSet<BS.Entities.UserAction> UserActions { get; set; }
        public DbSet<BS.Entities.WorkingDrawing> WorkingDrawings { get; set; }

        public static BusnessSystemDBContext Create()
        {
            return new BusnessSystemDBContext();
        }
    }
}