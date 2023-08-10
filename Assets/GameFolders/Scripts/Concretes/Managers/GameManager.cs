using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class GameManager : MonoBehaviour
    {
        private void OnEnable()
        {
            DataManager.Instance.EventData.OnPlayButton += OnPlayButtonHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnPlayButton -= OnPlayButtonHandler;
        }

        private void OnPlayButtonHandler()
        {
            int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(activeSceneIndex + 1);
        }
    }
}
