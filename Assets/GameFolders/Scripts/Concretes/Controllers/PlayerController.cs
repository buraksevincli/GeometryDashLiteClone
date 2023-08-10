using GameFolders.Scripts.Concretes.Movements;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private Mover _mover;
        private Jump _jump;

        private bool _isJump;
        private bool _canJump;
        
        private void Awake()
        {
            _mover = new Mover(this);
            _jump = new Jump(this);
        }

        private void FixedUpdate()
        {
            _mover.FixedTick();

            if (_isJump)
            {
                _jump.FixedTick();
                _isJump = false;
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && _canJump)
            {
                _isJump = true;
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Ground"))
            {
                _canJump = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _canJump = false;
            }
        }
    }
}
