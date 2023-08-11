using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class FlyRotator
    {
        private Rigidbody2D _rigidbody2D;
        
        public FlyRotator(Component playerController)
        {
            _rigidbody2D = playerController.GetComponent<Rigidbody2D>();
        }
        public void Tick(bool onGround, Transform transform)
        {
            if (!onGround)
            {
                if (_rigidbody2D.velocity.y > 0)
                {
                    Quaternion targetRotation = Quaternion.Euler(0f, 0f, 30f);
                
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, DataManager.Instance.GameData.FlyRotationSpeed * Time.deltaTime);
                }
                else
                {
                    Quaternion targetRotation = Quaternion.Euler(0f, 0f, -30f);
                
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, DataManager.Instance.GameData.FlyRotationSpeed * Time.deltaTime);
                }
            }
        }
    }
}
