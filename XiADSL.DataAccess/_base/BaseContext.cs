using System.Data.Entity;
using XiADSL.Arc;

namespace XiADSL.DataAccess._base
{

    public class BaseContext : DbContext, IDataContext
    {
        public BaseContext()
            : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }
        public BaseContext(string cs = "DefaultConnection")
            : base(cs)
        {

            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }
    }
    public class BaseContext<T> : BaseContext where T : DbContext
    {
        public BaseContext(string cs = "DefaultConnection")
            : base(cs)
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<T>());

        }




    }
}