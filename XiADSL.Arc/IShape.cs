namespace XiADSL.Arc
{

    public interface IShape
    {

    }
    public interface IShape<T> : IShape where T : BaseModel, new()
    {

    }
}