using System;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace GameFolders.Scripts.Concretes.UI
{
    public class SoundButton : MonoBehaviour
    {
        [SerializeField] private GameObject soundEnable;
        [SerializeField] private GameObject soundDisable;

        private Button _soundButton;

        private void Awake()
        {
            _soundButton = GetComponent<Button>();
        }

        private void Start()
        {
            soundEnable.SetActive(!GameManager.Instance.IsMusicMute);
            soundDisable.SetActive(GameManager.Instance.IsMusicMute);
        }

        private void OnEnable()
        {
            _soundButton.onClick?.AddListener(SoundButtonAction);
        }

        private void OnDisable()
        {
            _soundButton.onClick?.RemoveListener(SoundButtonAction);
        }

        private void SoundButtonAction()
        {
            soundEnable.SetActive(GameManager.Instance.IsMusicMute);
            soundDisable.SetActive(!GameManager.Instance.IsMusicMute);
            
            DataManager.Instance.EventData.OnSoundButton?.Invoke();
        }
    }
}
