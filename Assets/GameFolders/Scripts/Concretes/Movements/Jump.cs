using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class Jump
    {
        private Rigidbody2D _rigidbody2D;
        private Transform _transform;
        
        public Jump(Component playerController)
        {
            _rigidbody2D = playerController.GetComponent<Rigidbody2D>();
            _transform = playerController.GetComponent<Transform>();
        }

        public void FixedTick()
        {
            _rigidbody2D.AddForce(Vector2.up * DataManager.Instance.GameData.JumpForce);
        }
    }
}
