using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Obstacles
{
    public class BoxController : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (Mathf.Abs(col.contacts[0].point.x - transform.position.x) > transform.localScale.x / 2)
            {
                DataManager.Instance.EventData.OnGameOverCondition?.Invoke();
            }
        }
    }
}