using System.Collections.Generic;
using System.Data.Entity;
using XiADSL.Models.GeneralDomain;

namespace XiADSL.DataAccess.Migrations
{

    public class CustomInit<T> : DropCreateDatabaseAlways<T> where T : DbContext
    {
        //private readonly IEnumerable<IDataContext> _contexts;

        //public CustomInit(IEnumerable<IDataContext> contexts)
        //{
        //    _contexts = contexts;
        //}

        protected override void Seed(T context)
        {
            

            //foreach (var dbContext in _contexts)
            //{
            //    var sql = ((IObjectContextAdapter)dbContext).ObjectContext.CreateDatabaseScript();
            //    File.WriteAllText(string.Format(@"c:\database\{0}.sql", dbContext.GetType().Name), sql);
            //}

            base.Seed(context);
        }

        

        string CreateColumnScript(string tableName, string columnName, string type)
        {
            return string.Format(@"
            IF NOT EXISTS (SELECT 1 FROM sys.columns AS col
                           INNER JOIN sys.tables AS tab ON tab.object_Id = col.object_Id
                           WHERE tab.Name = '{0}' AND col.Name = '{1}')
            BEGIN
                ALTER TABLE {0} ADD {1} {2}; 
            END", tableName, columnName, type);
        }
    }



    public class MainInitializer : DropCreateDatabaseAlways<GeneralContext>
    {
        protected override void Seed(GeneralContext context)
        {
            IList<Employee> defaultEmployee = new List<Employee>();

            defaultEmployee.Add(new Employee() { Name = "Ibrahim" });
            defaultEmployee.Add(new Employee() { Name = "Sayed" });
            defaultEmployee.Add(new Employee() { Name = "Admin" });


            foreach (var std in defaultEmployee)
                context.Employees.Add(std);


            IList<Customer> defaultCustomers = new List<Customer>();

            defaultCustomers.Add(new Customer() { Name = "Ibrahim" });
            defaultCustomers.Add(new Customer() { Name = "Sayed" });
            defaultCustomers.Add(new Customer() { Name = "Admin" });


            foreach (var std in defaultCustomers)
                context.Customers.Add(std);

            //All standards will
            base.Seed(context);
        }
    }
}
