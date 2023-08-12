using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.UI
{
    public class PausePanel : MonoBehaviour
    {
        private void OnEnable()
        {
            Time.timeScale = 0f;
            DataManager.Instance.EventData.OnMusicStop?.Invoke(gameObject.activeSelf);
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;
            DataManager.Instance.EventData.OnMusicStop?.Invoke(gameObject.activeSelf);
        }
    }
}
