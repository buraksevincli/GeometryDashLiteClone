using GameFolders.Scripts.Concretes.Helpers;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class Fly
    {
        private Rigidbody2D _rigidbody2D;
        
        public Fly(Component playerController)
        {
            _rigidbody2D = playerController.GetComponent<Rigidbody2D>();
        }

        public void FixedTick()
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
            _rigidbody2D.AddForce(VectorTwoHelper.Up * (DataManager.Instance.GameData.FlyForce * Time.deltaTime),
                ForceMode2D.Impulse);
        }
    }
}
