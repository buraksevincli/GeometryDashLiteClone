using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.UI
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject winConditionPanel;
        
        private void OnEnable()
        {
            DataManager.Instance.EventData.OnWinCondition += OnWinConditionHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnWinCondition -= OnWinConditionHandler;
        }

        private void OnWinConditionHandler()
        {
            winConditionPanel.SetActive(true);
        }
    }
}
