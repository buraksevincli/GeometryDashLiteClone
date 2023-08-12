using GameFolders.Scripts.Abstracts.Enums;
using GameFolders.Scripts.Concretes.Managers;
using GameFolders.Scripts.Concretes.Movements;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform runBody;
        [SerializeField] private Transform flyBody;

        private Mover _mover;
        private Jump _jump;
        private Fly _fly;
        private FlyRotator _flyRotator;
        private OnGround _onGround;

        private Rigidbody2D _rigidbody2D;

        private bool _isJump;
        private bool _isFly;

        private void Awake()
        {
            _mover = new Mover(this);
            _jump = new Jump(this);
            _fly = new Fly(this);
            _flyRotator = new FlyRotator(this);
            _onGround = new OnGround(this);

            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            DataManager.Instance.EventData.OnChangeGamePlayState += OnChangeGamePlayStateHandler;
        }

        private void OnDisable()
        {
            DataManager.Instance.EventData.OnChangeGamePlayState -= OnChangeGamePlayStateHandler;
        }

        private void FixedUpdate()
        {
            _mover.FixedTick();

            switch (GameManager.Instance.ActiveGamePlayState)
            {
                case GamePlayState.Run:
                    if (_isJump)
                    {
                        _jump.FixedTick();
                        _isJump = false;
                    }

                    break;
                case GamePlayState.Fly:
                    if (_isFly)
                    {
                        _fly.FixedTick();
                    }

                    break;
            }
        }

        private void Update()
        {
            switch (GameManager.Instance.ActiveGamePlayState)
            {
                case GamePlayState.Run:

                    if (Input.GetMouseButton(0) && _onGround.Tick())
                    {
                        _isJump = true;
                        _jump.GetLandingTime();
                    }

                    break;
                case GamePlayState.Fly:

                    _flyRotator.Tick(_onGround.Tick(), flyBody);

                    if (Input.GetMouseButton(0))
                    {
                        _isFly = true;
                    }
                    else if (Input.GetMouseButtonUp(0))
                    {
                        _isFly = false;
                    }

                    break;
            }
        }

        private void OnChangeGamePlayStateHandler()
        {
            switch (GameManager.Instance.ActiveGamePlayState)
            {
                case GamePlayState.Run:
                    flyBody.gameObject.SetActive(false);
                    runBody.gameObject.SetActive(true);
                    _rigidbody2D.gravityScale = 6f;
                    break;
                case GamePlayState.Fly:
                    flyBody.gameObject.SetActive(true);
                    runBody.gameObject.SetActive(false);
                    _rigidbody2D.gravityScale = 3f;
                    break;
            }
        }
    }
}