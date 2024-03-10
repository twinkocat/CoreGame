namespace twinkocat.Core.Services.Interfaces
{
    public interface IServiceGetter
    {
        T Get<T>() where T : IService;
    }
}