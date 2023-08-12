using GameFolders.Scripts.Concretes.Helpers;
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

        public bool Tick(LayerMask groundLayer)
        {
            return Physics2D.Raycast(_transform.position, VectorHelper.Down, DataManager.Instance.GameData.GroundCheckRayDistance, groundLayer);
        }
    }
}
