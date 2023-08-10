using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class Rotator
    {
        private Transform _transform;
        
        public Rotator(Transform transform)
        {
            _transform = transform;
        }

        public void Tick(bool onGround)
        {
            
        }
    }
}
