using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using XiADSL.Arc;

namespace XiADSL.DataAccess._base
{

    public static class ModelExt
    {
        public static IEnumerable<string> IncludeList(this Type type)
        {
            return type.GetProperties()
                       .Where(t => t.PropertyType.IsSubclassOf(typeof(BaseModel)))
                       .Select(t => t.Name);
        }

        public static IQueryable<T> Include<T>(this DbSet<T> set) where T : class
        {
            IEnumerable<string> list = typeof(T).IncludeList();
            IQueryable<T> s = set;
            var enumerable = list as IList<string> ?? list.ToList();
            if (enumerable.Any())
            {
                s = enumerable.Aggregate(s, (current, prop) => current.Include(prop));
            }
            return s;
        }


        public static IQueryable<T> ActiveOnly<T>(this IQueryable<T> set) where T : BaseModel
        {
            var activeSet = set as IQueryable<IActive>;
            if (activeSet != null)
            {
                var x = Expression.Parameter(typeof(T), "x");

                var activeProperty = Expression.MakeMemberAccess(x, x.Type.GetProperty("Active"));

                var isTrue = Expression.Equal(activeProperty, Expression.Constant(true));
                Expression<Func<T, bool>> func = Expression.Lambda<Func<T, bool>>(isTrue, x);

                return set.Where(func);
            }
            return set;
        }


    }
    public class EFQueryRepository<T> : IQueryRepository<T> where T : BaseModel, new()
    {
        internal readonly IContext Context;
        internal readonly Lazy<DbContext> Db;

        internal DbSet<T> Set
        {
            get { return Db.Value.Set<T>(); }
        }

        public EFQueryRepository(ISessionManager sessionManager, IContext context)
        {
            Context = context;
            Db = new Lazy<DbContext>(sessionManager.Create<T>);
        }
        public IQueryable<T> Query
        {
            get
            {
                return Set.Include().ActiveOnly();
            }
        }
        public T GetById(int id)
        {
            return Set.Include().FirstOrDefault(x=>x.Id==id);
        }
    }
}