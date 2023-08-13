using UnityEngine;

namespace GameFolders.Scripts.Abstracts.Scriptables
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Data/Game Data")]
    public class GameData : ScriptableObject
    {
        [Header("Player Settings")]
        [SerializeField] private int moveSpeed;
        [SerializeField] private int jumpForce;
        [SerializeField] private int flyForce;
        [SerializeField] private int flyRotationSpeed;
        [SerializeField] private float deadTime;
        
        [Header("GroundCheck")]
        [SerializeField] private float groundCheckRayDistance;
        [SerializeField] private LayerMask groundLayer;

        public int MoveSpeed => moveSpeed;
        public int JumpForce => jumpForce;
        public int FlyForce => flyForce;
        public int FlyRotationSpeed => flyRotationSpeed;
        public float GroundCheckRayDistance => groundCheckRayDistance;
        public LayerMask GroundLayer => groundLayer;
        public float DeadTime => deadTime;
    }
}
