// file UISpriteAnimation.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

#region

using UnityEngine;
using UnityEngine.UI;

#endregion

namespace twinkocat.Core.Utilities
{
    [RequireComponent(typeof(Image))]
    public class UISpriteAnimation : MonoBehaviour
    {
        [SerializeField] private bool _isRevertable;
        [SerializeField] private int _fps;
        [SerializeField] private Sprite[] _sprites;

        private float _delta;
        private Image _image;
        private int _index;
        private bool _isReversing;
        private float _timer;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void Update()
        {
            if (!enabled) return;

            Animation(Time.deltaTime);
        }

        private void Animation(float deltaTime)
        {
            if (_fps <= 0 || _sprites.IsNullOrEmpty()) return;

            _timer += deltaTime;

            var interval = 1f / _fps;

            if (_timer < interval) return;

            _timer -= interval;
            _index = _isRevertable ? ReverseAnimation() : DefaultAnimation();
            _image.sprite = _sprites[_index];
        }

        private int DefaultAnimation()
        {
            return (_index + 1) % _sprites.Length;
        }

        private int ReverseAnimation()
        {
            if (_isReversing)
            {
                _index--;

                if (_index >= 0) return _index;

                _index = 1;
                _isReversing = false;
            }
            else
            {
                _index++;

                if (_index < _sprites.Length) return _index;

                _index = _sprites.Length - 2;
                _isReversing = true;
            }

            return _index;
        }
    }
}