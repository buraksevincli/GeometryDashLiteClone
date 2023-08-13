using GameFolders.Scripts.Concretes.Helpers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class Rotator
    {
        public void Tick(bool onGround, Transform transform)
        {
            if (onGround)
            {
                Vector3 rotation = transform.rotation.eulerAngles;
                rotation.z = Mathf.Round(rotation.z / 90) * 90;
                transform.rotation = Quaternion.Euler(rotation);
            }
            else
            {
                transform.Rotate(VectorThreeHelper.Back * 7);
            }
        }
    }
}
