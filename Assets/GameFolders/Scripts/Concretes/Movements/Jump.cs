using GameFolders.Scripts.Concretes.Helpers;
using GameFolders.Scripts.Concretes.Managers;
using GameFolders.Scripts.Concretes.Trajectory;
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
            Vector3 forceVector = new Vector2(_rigidbody2D.velocity.x * 2, DataManager.Instance.GameData.JumpForce);
            
            Vector3 landingPosition = DrawTrajectory.Instance.GetLandingTime(forceVector, _rigidbody2D, _rigidbody2D.position, DataManager.Instance.GameData.GroundLayer);

            return Mathf.Abs(CalculateLandingTime(landingPosition)) / 5;
        }
        
        private float CalculateLandingTime(Vector3 landingPosition)
        {
            float jumpHeight = _rigidbody2D.position.y - landingPosition.y;

            float timeToPeak = DataManager.Instance.GameData.JumpForce / (-_rigidbody2D.gravityScale);
            float timeToTarget = Mathf.Sqrt((2 * jumpHeight) / -_rigidbody2D.gravityScale);
            float timeInAir = timeToPeak + timeToTarget;

            return timeInAir;
        }
    }
}
