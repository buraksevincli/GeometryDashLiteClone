using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Effects
{
    public class ParticleController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particleEffect1;
        [SerializeField] private ParticleSystem particleEffect2;
        
        private void OnEnable()
        {
            DataManager.Instance.EventData.OnChangeGamePlayState += OnChangeGamePlayStateHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnChangeGamePlayState -= OnChangeGamePlayStateHandler;
        }

        private void OnChangeGamePlayStateHandler()
        {
            particleEffect1.Play();
            particleEffect2.Play();
        }
    }
}
