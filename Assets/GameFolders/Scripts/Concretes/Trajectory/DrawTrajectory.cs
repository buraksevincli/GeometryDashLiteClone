using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Utilities;
using UnityEngine;

public class DrawTrajectory : MonoSingleton<DrawTrajectory>
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private int lineSegmentCount = 20;
    [SerializeField] private float rayDistance;
    [SerializeField] private Transform visualHitObject;
    [SerializeField] private bool debugMode;

    private readonly List<Vector3> _points = new List<Vector3>();

    public float GetLandingTime(Vector2 forceVector, Rigidbody2D rigidbody, Vector3 startPoint, LayerMask layerMask)
    {
        Vector2 velocity = (forceVector / rigidbody.mass) * Time.fixedDeltaTime;
        float flightDuration = (2 * velocity.y) / Physics2D.gravity.y;
        float stepTime = flightDuration / lineSegmentCount;

        _points.Clear();

        for (int i = 0; i < lineSegmentCount; i++)
        {
            float stepTimePassed = stepTime * i;
            Vector3 movementVector = new Vector3(
                velocity.x * stepTimePassed,
                velocity.y * stepTimePassed - 1f * Physics2D.gravity.y * Mathf.Pow(stepTimePassed, 2));

            Vector3 newPosition = startPoint - movementVector;

            _points.Add(newPosition);

            if (debugMode)
            {
                visualHitObject.position = newPosition;
                lineRenderer.positionCount = _points.Count;
                lineRenderer.SetPositions(_points.ToArray());
            }

            if (_points.Count < 2) continue;

            if (!(_points[^2].y > newPosition.y)) continue; // Object goes up
            
            RaycastHit2D hit = Physics2D.Raycast(newPosition, Vector2.down, rayDistance, layerMask);

            if (hit.collider != null)
            {
                return Mathf.Abs(stepTimePassed);
            }
        }

        return 0;
    }

    private void OnValidate()
    {
        if (lineRenderer != null)
        {
            lineRenderer.gameObject.SetActive(debugMode);
        }

        if (visualHitObject != null)
        {
            visualHitObject.gameObject.SetActive(debugMode);
        }
    }
}
