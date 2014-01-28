using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XiADSL.Arc
{
    public interface IRepository<T> where T : BaseModel, new()
    {
        T ById(int id);
        IQueryable<T> Query { get; }
        void Add(T item);
        void Update(T item);
        void Update(T item, string[] attributies);
        bool Delete(int id);
        bool Delete(T item);
    }

    public abstract class BaseModel
    {
        public int Id { get; set; }
    }


    public interface IDataContext
    {

    }

    public interface IShape<T> where T : BaseModel, new()
    {

    }


    public interface IUser
    {
        string Name { get; }
        string LoginName { get; }
        int Id { get; }

        string[] Roles { get; }

        bool HasRole(string role);

    }

    public interface ILogger
    {
        void Log(string message);
    }

    public interface IContext
    {
        IUser User { get; }
        ILogger Logger { get; }
    }

}
