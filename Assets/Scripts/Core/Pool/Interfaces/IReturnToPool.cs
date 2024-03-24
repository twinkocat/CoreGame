namespace twinkocat.Core.Pool.Interfaces
{
    public interface IReturnToPool
    {
        /// <summary>
        ///     Invokes when object is return to pool.
        /// </summary>
        void OnReturn();
    }
}