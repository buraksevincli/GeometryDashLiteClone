using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class Mover
    {
        private readonly Rigidbody2D _rigidbody2D;
        
        public Mover(Component playerController)
        {
            _rigidbody2D = playerController.GetComponent<Rigidbody2D>();
        }

        public void FixedTick()
        {
            _rigidbody2D.velocity = new Vector2(DataManager.Instance.GameData.MoveSpeed, _rigidbody2D.velocity.y);
        }
    }
}
