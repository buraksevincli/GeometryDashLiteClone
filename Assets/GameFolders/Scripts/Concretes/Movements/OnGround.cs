using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class OnGround
    {
        private readonly Transform _transform;
        
        public OnGround(Component playerController)
        {
            _transform = playerController.GetComponent<Transform>();
        }

        public bool Tick()
        {
            return Physics2D.OverlapCircle(_transform.position, DataManager.Instance.GameData.GroundCheckRayDistance, DataManager.Instance.GameData.GroundLayer);
        }
    }
}
