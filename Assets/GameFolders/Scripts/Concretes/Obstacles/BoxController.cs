using GameFolders.Scripts.Concretes.Controllers;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Obstacles
{
    public class BoxController : MonoBehaviour
    {
        private Transform _transform;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.gameObject.TryGetComponent(out PlayerController playerController)) return;
            
            if (Mathf.Abs(col.contacts[0].point.x - _transform.position.x) > _transform.localScale.x / 2)
            {
                DataManager.Instance.EventData.OnGameOverCondition?.Invoke();
            }
        }
    }
}