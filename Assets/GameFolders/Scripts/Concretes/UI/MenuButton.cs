using GameFolders.Scripts.Abstracts.Enums;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameFolders.Scripts.Concretes.UI
{
    public class MenuButton : MonoBehaviour
    {
        private Button _menuButton;

        private void Awake()
        {
            _menuButton = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _menuButton.onClick?.AddListener(MenuButtonAction);
        }

        private void OnDisable()
        {
            _menuButton.onClick?.RemoveListener(MenuButtonAction);
        }

        private void MenuButtonAction()
        {
            GameManager.Instance.SetActiveGameState(GameState.Menu);
            
            SceneManager.LoadSceneAsync(0);
        }
    }
}
