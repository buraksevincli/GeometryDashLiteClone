using GameFolders.Scripts.Abstracts.Enums;
using GameFolders.Scripts.Abstracts.Utilities;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public GameState ActiveGameState { get; private set; } = GameState.Menu;

        private void Start()
        {
            DataManager.Instance.EventData.OnSetMusic?.Invoke();
        }

        public void SetActiveGameState(GameState state)
        {
            ActiveGameState = state;
            
            DataManager.Instance.EventData.OnSetMusic?.Invoke();
        }
    }
}
