using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using XiADSL.Arc;

namespace XiADSL.DataAccess._base
{
    public class SessionManager : ISessionManager
    {
        readonly Dictionary<Type, Type> _typesContext;

        public SessionManager(IEnumerable<IDataContext> contexts)
        {
            _typesContext = new Dictionary<Type, Type>();
            foreach (var context in contexts)
            {
                var types = context.GetType()
                                   .GetProperties()
                                   .Where(p => p.PropertyType.IsGenericType)
                                   .Where(p => p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                                   .Where(p => !p.PropertyType.GetGenericArguments()[0].GetInterfaces().Contains(typeof(IShape)))
                                   .Select(p => p.PropertyType.GetGenericArguments()[0])
                    ;

                foreach (var type in types)
                {
                    _typesContext.Add(type, context.GetType());
                }

            }

            foreach (var dbContext in contexts)
            {
                var sql = ((IObjectContextAdapter)dbContext).ObjectContext.CreateDatabaseScript();
                File.WriteAllText(string.Format(@"c:\database\{0}.sql", dbContext.GetType().Name), sql);
            }

        }

        public DbContext Create<T>() where T : BaseModel, new()
        {
            return Activator.CreateInstance(_typesContext[typeof(T)]) as DbContext;
        }

    }

    
}