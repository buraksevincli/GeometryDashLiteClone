using GameFolders.Scripts.Abstracts.Enums;
using GameFolders.Scripts.Concretes.Movements;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform bodyTransform;

        private readonly GamePlayState _gamePlayState = GamePlayState.Run;
        
        private Mover _mover;
        private Jump _jump;
        private Rotator _rotator;
        
        private bool _isJump;
        private bool _onGround;
        
        private void Awake()
        {
            _mover = new Mover(this);
            _jump = new Jump(this);
            _rotator = new Rotator(bodyTransform);
        }

        private void FixedUpdate()
        {
            switch (_gamePlayState)
            {
                case GamePlayState.Run:
                    _mover.FixedTick();

                    if (_isJump)
                    {
                        _jump.FixedTick();
                        _isJump = false;
                    }
                    break;
                case GamePlayState.Fly:
                    //uçma kontrolleri
                    break;
            }
            
        }

        private void Update()
        {
            switch (_gamePlayState)
            {
                case GamePlayState.Run:

                    _rotator.Tick(_onGround);
                    
                    if (Input.GetMouseButton(0) && _onGround)
                    {
                        _isJump = true;
                    }
                    
                    break;
                case GamePlayState.Fly:
                    //uçma kontrolleri
                    break;
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            switch (_gamePlayState)
            {
                case GamePlayState.Run:
                    if (col.gameObject.CompareTag("Ground"))
                    {
                        _onGround = true;
                    }
                    break;
                case GamePlayState.Fly:
                    //uçma kontrolleri
                    break;
            }
            
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            switch (_gamePlayState)
            {
                case GamePlayState.Run:
                    if (other.gameObject.CompareTag("Ground"))
                    {
                        _onGround = false;
                    }
                    break;
                case GamePlayState.Fly:
                    //uçma kontrolleri
                    break;
            }
        }
    }
}
