using System.Data.Entity;

namespace XiADSL.Arc
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
    }

    public interface IActive
    {
        bool Active { get; set; }
    }

    public interface ISessionManager
    {
        DbContext Create<T>() where T : BaseModel, new();
    }
}