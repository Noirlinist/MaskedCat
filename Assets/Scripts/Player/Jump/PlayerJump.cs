using Input;
using UnityEngine;
using Tools;
using System;
using FMODUnity;
using Managers;

namespace Player.Jump
{
    public class PlayerJump : MonoBehaviour
    {
        [Header("Jump Settings")]
        [SerializeField] private float jumpForce = 7f;
        [SerializeField] private float jumpCutMultiplier = 0.5f;
        [SerializeField] private float jumpBufferTime = 0.15f;
        [SerializeField] private float coyoteTime = 0.15f;
        [SerializeField] private EventReference jumpSFX;

        // Variables
        private bool _isGrounded;
        private float _jumpBufferCounter;
        private float _coyoteTimeCounter;
        
        // Events
        public static event Action OnPlayerJump;
        
        // Components
        private InputHandler _inputHandler;
        private GroundChecker _groundChecker;
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;

        private void Awake()
        {
            _groundChecker = GetComponentInChildren<GroundChecker>();
            if (_groundChecker == null)
                Debug.LogError($"{nameof(_groundChecker)} is null");
            
            _rigidbody2D = GetComponent<Rigidbody2D>();
            if (_rigidbody2D == null)
                Debug.LogError($"{nameof(_rigidbody2D)} is null");
            
            _animator = GetComponent<Animator>();
        }
        
        private void Start()
        {
            _inputHandler = InputHandler.Instance;
            if (_inputHandler == null)
                Debug.LogError($"{nameof(_inputHandler)} is null");
            
            _inputHandler.OnJump += Jump;
            _inputHandler.OnJumpReleased += CutJump;
        }

        private void OnDestroy()
        {
            if (_inputHandler != null)
            {
                _inputHandler.OnJump -= Jump;
                _inputHandler.OnJumpReleased -= CutJump;
            }
        }

        private void FixedUpdate()
        {
            _isGrounded = _groundChecker.IsGrounded;
            
            if (_isGrounded)
            {
                _coyoteTimeCounter = coyoteTime;
            }
            else
            {
                _coyoteTimeCounter -= Time.deltaTime;
            }
            
            _jumpBufferCounter -= Time.deltaTime;
            
            if (_jumpBufferCounter > 0 && _coyoteTimeCounter > 0)
            {
                PerformJump();
            }

            HandleAnimation();
        }

        private void Jump()
        {
            _jumpBufferCounter = jumpBufferTime;
        }
        
        private void PerformJump()
        {
            _rigidbody2D.linearVelocity = new Vector2(
                _rigidbody2D.linearVelocity.x,
                jumpForce
            );
            SoundManager.Instance.PlayOneShot(
                jumpSFX,
                transform.position
            );

            OnPlayerJump?.Invoke();

            _jumpBufferCounter = 0;
            _coyoteTimeCounter = 0;
        }
        
        private void CutJump()
        {
            if (_rigidbody2D.linearVelocity.y > 0)
            {
                _rigidbody2D.linearVelocity = new Vector2(
                    _rigidbody2D.linearVelocity.x,
                    _rigidbody2D.linearVelocity.y * jumpCutMultiplier
                );
            }
        }

        private void HandleAnimation()
        {
            _animator.SetBool("isGrounded",  _isGrounded);
        }
    }
}
