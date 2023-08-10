using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Vector3 offset;

        private Transform _transform;

        private void Awake()
        {
            _transform = GetComponent<Transform>(); // for performance
        }

        private void LateUpdate()
        {
            if (playerTransform)
            {
                Vector3 targetPosition =
                    new Vector3(playerTransform.position.x + offset.x,
                        _transform.position.y + offset.y,
                        _transform.position.z + offset.z);

                _transform.position = targetPosition;
            }
        }
    }
}
