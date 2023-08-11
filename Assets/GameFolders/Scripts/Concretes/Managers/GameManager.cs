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

        private void Start()
        {
            Application.targetFrameRate = 60;
            
            DataManager.Instance.EventData.OnSetMusic?.Invoke();
        }

        private void OnEnable()
        {
            DataManager.Instance.EventData.OnGameOverCondition += OnGameOverConditionHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnGameOverCondition += OnGameOverConditionHandler;
        }

        private void OnGameOverConditionHandler()
        {
            int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(activeSceneIndex);

            ActiveGamePlayState = GamePlayState.Run;
        }

        public void SetActiveGameState(GameState state)
        {
            ActiveGameState = state;
            
            DataManager.Instance.EventData.OnSetMusic?.Invoke();
        }

        public void ChangeActiveGamePlayState()
        {
            ActiveGamePlayState = ActiveGamePlayState switch
            {
                GamePlayState.Run => GamePlayState.Fly,
                GamePlayState.Fly => GamePlayState.Run,
                _ => ActiveGamePlayState
            };
            
            DataManager.Instance.EventData.OnChangeGamePlayState?.Invoke();
        }
    }
}
