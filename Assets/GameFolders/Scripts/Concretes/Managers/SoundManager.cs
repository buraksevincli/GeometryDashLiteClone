using GameFolders.Scripts.Abstracts.Enums;
using GameFolders.Scripts.Abstracts.Utilities;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class SoundManager : MonoSingleton<SoundManager>
    {
        [SerializeField] private AudioClip[] audios;

        private AudioSource _audioSource;

        protected override void Awake()
        {
            base.Awake();

            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            DataManager.Instance.EventData.OnSoundButton += OnSoundButtonHandler;
            DataManager.Instance.EventData.OnSetMusic += OnSetMusicHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnSoundButton -= OnSoundButtonHandler;
            DataManager.Instance.EventData.OnSetMusic -= OnSetMusicHandler;
        }

        private void OnSetMusicHandler()
        {
            switch (GameManager.Instance.ActiveGameState)
            {
                case GameState.Menu:
                    _audioSource.clip = audios[0];
                    _audioSource.Play();
                    break;
                case GameState.Play:
                    _audioSource.clip = audios[1];
                    _audioSource.Play();
                    break;
            }
        }

        private void OnSoundButtonHandler()
        {
            _audioSource.mute = !_audioSource.mute;
        }
    }
}
