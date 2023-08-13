using System.Collections;
using GameFolders.Scripts.Abstracts.Enums;
using GameFolders.Scripts.Abstracts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public GameState ActiveGameState { get; private set; } = GameState.Menu;
        public GamePlayState ActiveGamePlayState { get; private set; } = GamePlayState.Run;

        public bool IsMusicMute { get; set; }

        private WaitForSeconds _waitForDead;
        public bool isDead;

        protected override void Awake()
        {
            base.Awake();
            _waitForDead = new WaitForSeconds(DataManager.Instance.GameData.DeadTime);
        }

        private void Start()
        {
            Application.targetFrameRate = 60;
        }

        private void OnEnable()
        {
            DataManager.Instance.EventData.OnChangeGamePlayState += ChangeActiveGamePlayState;
            DataManager.Instance.EventData.OnGameOverCondition += OnGameOverConditionHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnChangeGamePlayState -= ChangeActiveGamePlayState;
            DataManager.Instance.EventData.OnGameOverCondition -= OnGameOverConditionHandler;
        }

        private void OnGameOverConditionHandler()
        {
            StartCoroutine(GameOver());
        }

        public void SetActiveGameState(GameState state)
        {
            ActiveGameState = state;
            
            DataManager.Instance.EventData.OnSetMusic?.Invoke();
        }

        private void ChangeActiveGamePlayState()
        {
            ActiveGamePlayState = ActiveGamePlayState switch
            {
                GamePlayState.Run => GamePlayState.Fly,
                GamePlayState.Fly => GamePlayState.Run,
                _ => ActiveGamePlayState
            };
        }

        private IEnumerator GameOver()
        {
            if (isDead) yield break;

            isDead = true;
            
            DataManager.Instance.EventData.OnDead?.Invoke();

            ActiveGameState = GameState.Play;
            ActiveGamePlayState = GamePlayState.Run;

            yield return _waitForDead;
            
            int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(activeSceneIndex);
        }
    }
}
