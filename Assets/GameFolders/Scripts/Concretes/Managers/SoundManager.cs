using GameFolders.Scripts.Abstracts.Enums;
using GameFolders.Scripts.Abstracts.Utilities;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class SoundManager : MonoSingleton<SoundManager>
    {
        [SerializeField] private AudioClip[] audios;

        private AudioSource _audioSource;
        private float _musicTime;

        protected override void Awake()
        {
            base.Awake();

            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            DataManager.Instance.EventData.OnSetMusic?.Invoke();
        }

        private void OnEnable()
        {
            DataManager.Instance.EventData.OnSoundButton += OnSoundButtonHandler;
            DataManager.Instance.EventData.OnSetMusic += OnSetMusicHandler;
            DataManager.Instance.EventData.OnMusicStop += OnMusicStopHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnSoundButton -= OnSoundButtonHandler;
            DataManager.Instance.EventData.OnSetMusic -= OnSetMusicHandler;
            DataManager.Instance.EventData.OnMusicStop -= OnMusicStopHandler;
        }

        private void OnSetMusicHandler()
        {
            switch (GameManager.Instance.ActiveGameState)
            {
                case GameState.Menu:
                    _audioSource.clip = audios[0];
                    _audioSource.Play();
                    _audioSource.mute = GameManager.Instance.IsMusicMute;
                    break;
                case GameState.Play:
                    _audioSource.clip = audios[1];
                    _audioSource.Play();
                    _audioSource.mute = GameManager.Instance.IsMusicMute;
                    break;
                case GameState.Dead:
                    _audioSource.clip = audios[2];
                    _audioSource.loop = false;
                    _audioSource.Play();
                    _audioSource.mute = GameManager.Instance.IsMusicMute;
                    break;
            }
        }

        private void OnSoundButtonHandler()
        {
            _audioSource.mute = !_audioSource.mute;
            GameManager.Instance.IsMusicMute = _audioSource.mute;
        }
        
        private void OnMusicStopHandler(bool panelSetActive)
        {
            switch (panelSetActive)
            {
                case true:
                    _musicTime = _audioSource.time;
                    _audioSource.Stop();
                    break;
                case false:
                    _audioSource.time = _musicTime;
                    _audioSource.Play();
                    break;
            }
        }
    }
}
