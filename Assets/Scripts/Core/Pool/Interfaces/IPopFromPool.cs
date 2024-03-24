namespace twinkocat.Core.Pool.Interfaces
{
    public interface IPopFromPool
    {
        /// <summary>
        ///     Invokes when object is popped from pool.
        /// </summary>
        void OnPop();
    }
}