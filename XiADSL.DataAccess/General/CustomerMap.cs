using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using XiADSL.Models.GeneralDomain;

namespace XiADSL.DataAccess.General
{

    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            HasKey(t => t.Id);
            ToTable("Employees");

            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name").IsRequired();
            Property(t => t.Address).HasColumnName("Address");
            Property(t => t.Custom1).HasColumnName("Custom1");
            Property(t => t.Custom2).HasColumnName("Custom2");
            Property(t => t.Custom3).HasColumnName("Custom3");
            Property(t => t.Custom4).HasColumnName("Custom4");
            
            
            
            Property(t => t.Mobile1).HasColumnName("Mobile1");
            Property(t => t.Mobile2).HasColumnName("Mobile2");
            Property(t => t.Note).HasColumnName("Note");
            Property(t => t.PersonalCardNumber).HasColumnName("Personalid");
            Property(t => t.Phone1).HasColumnName("Phone1");
            Property(t => t.Phone2).HasColumnName("Phone2");
            




        }
    }

    public class CustomerMap:EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            HasKey(t => t.Id);
            ToTable("Customer");

            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name").IsRequired();
            Property(t => t.Address).HasColumnName("Address");
            Property(t => t.Custom1).HasColumnName("Custom1");
            Property(t => t.Custom2).HasColumnName("Custom2");
            Property(t => t.Custom3).HasColumnName("Custom3");
            Property(t => t.Custom4).HasColumnName("Custom4");
            Property(t => t.Facebook).HasColumnName("Facebook");
            Property(t => t.Mail1).HasColumnName("Mail1");
            Property(t => t.Mail2).HasColumnName("Mail2");
            Property(t => t.Mobile1).HasColumnName("Mobile1");
            Property(t => t.Mobile2).HasColumnName("Mobile2");
            Property(t => t.Note).HasColumnName("Note");
            Property(t => t.PersonalCardNumber).HasColumnName("Personalid");
            Property(t => t.Phone1).HasColumnName("Phone1");
            Property(t => t.Phone2).HasColumnName("Phone2");
            Property(t => t.Twitter).HasColumnName("Twitter");
            Property(t => t.ParentId).HasColumnName("ParentId");


            HasOptional(x => x.Parent).WithMany().HasForeignKey(x => x.ParentId);




        }
    }
}
