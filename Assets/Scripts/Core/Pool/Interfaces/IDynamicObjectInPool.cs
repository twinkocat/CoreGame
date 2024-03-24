namespace twinkocat.Core.Pool.Interfaces
{
    /// <summary>
    ///     Delete object from pool
    ///     if NotUsedIteration more than NotUsedIterationLimit
    /// </summary>
    public interface IDynamicObjectInPool
    {
        int NotUsedIteration { get; set; }
        int NotUsedIterationLimit { get; }
    }
}