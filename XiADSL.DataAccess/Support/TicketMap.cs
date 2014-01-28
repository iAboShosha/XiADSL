using System.Data.Entity.ModelConfiguration;
using XiADSL.Models.SupportDomain;

namespace XiADSL.DataAccess.Support
{

    public class ProblemMap : EntityTypeConfiguration<Problem>
    {

        public ProblemMap()
        {
            HasKey(t => t.Id);
            ToTable("Problem");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name").IsRequired();
            Property(t => t.Description).HasColumnName("Description");
        }
    }

    public class StatusMap : EntityTypeConfiguration<Status>
    {

        public StatusMap()
        {
            HasKey(t => t.Id);
            ToTable("Status");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name").IsRequired();
            Property(t => t.Description).HasColumnName("Description");
        }
    }


    public class ActionMap : EntityTypeConfiguration<Action>
    {

        public ActionMap()
        {
            HasKey(t => t.Id);
            ToTable("Action");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.CreatorId).HasColumnName("CreatorId");
            Property(t => t.Note).HasColumnName("Note");
            Property(t => t.StatusId).HasColumnName("StatusId");
            Property(t => t.TicketId).HasColumnName("TicketId");

            HasRequired(t => t.Creator).WithMany().HasForeignKey(t => t.CreatorId);
            HasRequired(t => t.Status).WithMany().HasForeignKey(t => t.StatusId);

        }
    }

    public class TicketMap:EntityTypeConfiguration<Ticket>
    {
        public TicketMap()
        {
            HasKey(t => t.Id);
            ToTable("Tickets");

            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.CloseNode).HasColumnName("CloseNode");
            Property(t => t.Created).HasColumnName("Created");
            Property(t => t.AssingnId).HasColumnName("AssingnId");
            Property(t => t.CreatorId).HasColumnName("CreatorId");
            Property(t => t.CustomerId).HasColumnName("CustomerId");

            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.IsClosed).HasColumnName("IsClosed");
            
            Property(t => t.ProblemId).HasColumnName("ProblemId");
            Property(t => t.ReSolved).HasColumnName("ReSolved");
            Property(t => t.StatusId).HasColumnName("StatusId");
            //Property(t => t.Actions).HasColumnName("Mobile2");
            //Property(t => t.Assingn).HasColumnName("Note");
            //Property(t => t.Creator).HasColumnName("Personalid");
            //Property(t => t.Customer).HasColumnName("Phone1");
            //Property(t => t.Problem).HasColumnName("Phone2");
            //Property(t => t.Status).HasColumnName("Twitter");



            HasRequired(x => x.Creator).WithMany().HasForeignKey(x => x.CreatorId).WillCascadeOnDelete(false);
            HasOptional(x => x.Assingn).WithMany().HasForeignKey(x => x.AssingnId);

            HasRequired(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId).WillCascadeOnDelete(false);
            
            HasRequired(x => x.Status).WithMany().HasForeignKey(x => x.StatusId).WillCascadeOnDelete(false);
            HasRequired(x => x.Problem).WithMany().HasForeignKey(x => x.ProblemId).WillCascadeOnDelete(false);

            HasMany(x => x.Actions);







        }
    }
}
