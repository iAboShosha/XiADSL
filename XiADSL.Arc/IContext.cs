namespace XiADSL.Arc
{
    public interface IContext
    {
        IUser User { get; }
        ILogger Logger { get; }
    }
}