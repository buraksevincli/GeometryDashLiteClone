using GameFolders.Scripts.Abstracts.Enums;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameFolders.Scripts.Concretes.UI
{
    public class PlayButton : MonoBehaviour
    {
        private Button _playButton;

        private void Awake()
        {
            _playButton = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _playButton.onClick?.AddListener(PlayButtonAction);
        }

        private void OnDisable()
        {
            _playButton.onClick?.RemoveListener(PlayButtonAction);
        }

        private void PlayButtonAction()
        {
            GameManager.Instance.SetActiveGameState(GameState.Play);

            SceneManager.LoadScene(1);
        }
    }
}
