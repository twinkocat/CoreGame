using System.Threading.Tasks;
using twinkocat.Core.Enums;

namespace twinkocat.Core.Interfaces
{
    public interface ISceneLoader
    {
        Task LoadScenes(SceneGroup groupType, bool loadScreenActive = true, bool reloadDubScene = false);
        Task UnloadScenes();
    }
}