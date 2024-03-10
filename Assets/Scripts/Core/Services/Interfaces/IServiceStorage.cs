namespace twinkocat.Core.Services.Interfaces
{
    public interface IServiceStorage
    {
        void Add(IService service);
        bool Remove<T>()  where T : IService;
        void Clear();
    }
}