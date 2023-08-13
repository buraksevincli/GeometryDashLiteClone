using GameFolders.Scripts.Concretes.Controllers;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Obstacles
{
    public class ObstacleController : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent(out PlayerController playerController))
            {
                DataManager.Instance.EventData.OnGameOverCondition?.Invoke();
            }
        }
    }
}