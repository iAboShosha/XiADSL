using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using XiADSL.Arc;
using EntityState = System.Data.Entity.EntityState;

namespace XiADSL.DataAccess._base
{
    public class EFRepository<T> : EFQueryRepository<T>, IRepository<T> where T : BaseModel, new()
    {


        public EFRepository(ISessionManager sessionManager, IContext context)
            : base(sessionManager, context)
        {
        }

        void Save()
        {
            Db.Value.SaveChanges();
        }

        DbEntityEntry Entry(T item)
        {
            return Db.Value.Entry(item);
        }
        public virtual void Add(T item)
        {
            DbEntityEntry dbEntityEntry = Entry(item);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                //    dbEntityEntry.State = EntityState.Added;
                //}
                //else
                //{
                Set.Add(item);
                Save();
            }

        }


        public virtual void Update(T item)
        {

            DbEntityEntry dbEntityEntry = Entry(item);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Set.Attach(item);
            }
            dbEntityEntry.State = EntityState.Modified;

            Save();
        }

        public void Update(T item, string[] attributies)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
                Save();
            }
            //else
            //{
            //    Set.Attach(entity);
            //    Set.Remove(entity);
            //}

        }

        public void Delete(int id)
        {
            var item = new T { Id = id };
            Delete(item);

        }



    }
}
