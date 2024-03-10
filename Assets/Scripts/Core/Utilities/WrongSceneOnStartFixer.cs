using UnityEngine;
using UnityEngine.SceneManagement;

namespace twinkocat.Core.Utilities
{
    public static class WrongSceneOnStartFixer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        private static void Init()
        {
            if (SceneManager.GetActiveScene().name.Equals("Bootstrap")) return;
            
            Debug.LogWarning("WrongScene for first loading! Load Bootstrap Scene");
            
            SceneManager.LoadScene("Bootstrap");
        }
    }
}