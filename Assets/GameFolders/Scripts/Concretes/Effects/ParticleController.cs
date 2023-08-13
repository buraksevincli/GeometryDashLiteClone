using GameFolders.Scripts.Abstracts.Enums;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Effects
{
    public class ParticleController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particleEffect1;
        [SerializeField] private ParticleSystem particleEffect2;
        [SerializeField] private ParticleSystem runBodyParticle;
        [SerializeField] private ParticleSystem flyBodyParticle;
        
        private void OnEnable()
        {
            DataManager.Instance.EventData.OnChangeGamePlayState += OnChangeGamePlayStateHandler;
            DataManager.Instance.EventData.OnDead += OnDeadHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnChangeGamePlayState -= OnChangeGamePlayStateHandler;
            DataManager.Instance.EventData.OnDead -= OnDeadHandler;
        }

        private void OnChangeGamePlayStateHandler()
        {
            particleEffect1.Play();
            particleEffect2.Play();

            switch (GameManager.Instance.ActiveGamePlayState)
            {
                case GamePlayState.Run:
                    runBodyParticle.Play();
                    flyBodyParticle.Stop();
                    break;
                case GamePlayState.Fly:
                    runBodyParticle.Stop();
                    flyBodyParticle.Play();
                    break;
            }
        }
        
        private void OnDeadHandler()
        {
            GameManager.Instance.SetActiveGameState(GameState.Dead);
            particleEffect2.Play();
        }
    }
}
