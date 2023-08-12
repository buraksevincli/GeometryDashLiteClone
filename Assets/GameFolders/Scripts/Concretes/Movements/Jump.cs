using GameFolders.Scripts.Concretes.Helpers;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class Jump
    {
        private Rigidbody2D _rigidbody2D;
        
        public Jump(Component playerController)
        {
            _rigidbody2D = playerController.GetComponent<Rigidbody2D>();
        }

        public void FixedTick()
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
            _rigidbody2D.AddForce(VectorHelper.Up * DataManager.Instance.GameData.JumpForce, ForceMode2D.Impulse);
        }

        public float GetLandingTime()
        {
            Vector3 forceVector = new Vector2(_rigidbody2D.velocity.x * _rigidbody2D.mass / Time.fixedDeltaTime, DataManager.Instance.GameData.JumpForce);
            
            float landingTime = DrawTrajectory.Instance.GetLandingTime(forceVector, _rigidbody2D, _rigidbody2D.position, DataManager.Instance.GameData.GroundLayer);

            return landingTime;
        }
        
        
    }
}
