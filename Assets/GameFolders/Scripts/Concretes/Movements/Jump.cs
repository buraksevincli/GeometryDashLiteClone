using GameFolders.Scripts.Concretes.Helpers;
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
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
            _rigidbody2D.AddForce(VectorHelper.Up * DataManager.Instance.GameData.JumpForce, ForceMode2D.Impulse);
        }
    }
}
