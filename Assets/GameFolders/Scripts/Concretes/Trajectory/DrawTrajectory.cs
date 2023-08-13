using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Utilities;
using GameFolders.Scripts.Concretes.Helpers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Trajectory
{
    public class DrawTrajectory : MonoSingleton<DrawTrajectory>
    {
        [SerializeField] private int segmentCount = 20;
        [SerializeField] private float rayDistance;
        [SerializeField] private Transform visualHitObject;
        [SerializeField] private bool debugMode;

        private readonly List<Vector3> _points = new List<Vector3>();

        public Vector3 GetLandingTime(Vector2 velocity, Rigidbody2D rigidbody2D, Vector3 startPoint, LayerMask layerMask)
        {
            float flightDuration = (2 * velocity.y) / (Physics2D.gravity.y * rigidbody2D.gravityScale);
            float stepTime = flightDuration / segmentCount;

            _points.Clear();

            for (int i = 0; i < segmentCount; i++)
            {
                float stepTimePassed = stepTime * i;
                Vector3 movementVector = new Vector3(
                    velocity.x * stepTimePassed,
                    velocity.y * stepTimePassed - 1f * Physics2D.gravity.y * rigidbody2D.gravityScale * Mathf.Pow(stepTimePassed, 2));

                Vector3 newPosition = startPoint - movementVector;

                _points.Add(newPosition);

                if (debugMode)
                {
                    visualHitObject.position = newPosition;
                }

                if (_points.Count < 2) continue;

                if (!(_points[^2].y > newPosition.y)) continue;
            
                RaycastHit2D hit = Physics2D.Raycast(newPosition, VectorTwoHelper.Down, rayDistance, layerMask);

                if (hit.collider != null)
                {
                    return newPosition;
                }
            }

            return VectorThreeHelper.Zero;
        }

        private void OnValidate()
        {
            if (visualHitObject != null)
            {
                visualHitObject.gameObject.SetActive(debugMode);
            }
        }
    }
}