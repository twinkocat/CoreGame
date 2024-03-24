// file MusicService.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System;
using DG.Tweening;
using twinkocat.Core.Services.Interfaces;
using twinkocat.Core.Utilities;
using twinkocat.Storages;
using UnityEngine;
using Object = UnityEngine.Object;

namespace twinkocat.Gameplay.Global.Services
{
    public class MusicService : IService
    {
        private readonly AudioSource _musicSource = UnityExtensions.SpawnComponent<AudioSource>().DontDestroyOnLoad();
        private Coroutine _callbackRoutine;

        public void OnSetup()
        {
            _musicSource.playOnAwake = false;
        }

        public void Dispose()
        {
            StopMusic();
            Object.Destroy(_musicSource.gameObject);
        }

        public void SetVolume(float volume)
        {
            _musicSource.volume = volume;
        }

        public void SetFade(float duration, float endValue)
        {
            _musicSource.DOFade(endValue, duration);
        }

        public void PlayMusic(Music music, bool loop = false)
        {
            if (!StorageGetter.TryGetMusicClipFromStorage(music, out var clip)) return;

            _musicSource.loop = loop;
            _musicSource.clip = clip;
            _musicSource.Play();
        }

        public void PlayMusicWithCallback(Music music, Action onMusicEnd)
        {
            if (!StorageGetter.TryGetMusicClipFromStorage(music, out var clip)) return;

            _musicSource.loop = false;
            _musicSource.clip = clip;
            _callbackRoutine = _musicSource.PlayWithPossibleNullEndCallback(onMusicEnd);
        }

        public void FadeAndStop(float timeToFade)
        {
            _musicSource.DOFade(0, timeToFade)
                .OnComplete(StopMusic);
        }

        public void StopMusic()
        {
            _musicSource.Stop();
            StopRoutine();
        }

        private void StopRoutine()
        {
            if (_callbackRoutine is null) return;

            Coroutines.StopCoroutine(_callbackRoutine);

            _callbackRoutine = null;
        }
    }
}