using GameFolders.Scripts.Abstracts.Utilities;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class SoundManager : MonoSingleton<SoundManager>
    {
        private AudioSource _audioSource;

        protected override void Awake()
        {
            base.Awake();

            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            DataManager.Instance.EventData.OnSoundButton += OnSoundButtonHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnSoundButton -= OnSoundButtonHandler;
        }

        private void OnSoundButtonHandler()
        {
            _audioSource.mute = !_audioSource.mute;
        }
    }
}
