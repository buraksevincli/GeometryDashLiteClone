using UnityEngine;

namespace GameFolders.Scripts.Abstracts.Scriptables
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Data/Game Data")]
    public class GameData : ScriptableObject
    {
        [SerializeField] private int moveSpeed;
        [SerializeField] private int jumpForce;

        public int MoveSpeed => moveSpeed;
        public int JumpForce => jumpForce;
    }
}
