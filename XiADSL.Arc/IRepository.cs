using System.Linq;

namespace XiADSL.Arc
{

    public interface IQueryRepository<T> where T : BaseModel
    {
        T GetById(int id);
        IQueryable<T> Query { get; }
    }
    public interface IRepository<T> : IQueryRepository<T> where T : BaseModel, new()
    {

        void Add(T item);
        void Update(T item);
        void Update(T item, string[] attributies);
        void Delete(int id);
        void Delete(T item);
    }
}