using UnityEngine;

namespace twinkocat.Core.Scenes
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Canvas     _loadingCanvas;
        [SerializeField] private Camera     _loadingCamera;

        private float _targetProgress;

        public void ShowLoading() => EnableLoadingCanvas();

        public void HideLoading() => EnableLoadingCanvas(false);

        private void EnableLoadingCanvas(bool enable = true)
        {
            _loadingCanvas.gameObject.SetActive(enable);
            _loadingCamera.gameObject.SetActive(enable);
        }
    }
}