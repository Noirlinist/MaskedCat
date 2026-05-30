using Input;
using UnityEngine;
using Tools;

namespace Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField]  private float movementSpeed = 5f;
        
        [Header("Visual Settings")]
        [SerializeField]  private ParticleSystem poofParticle;
        
        // Variables
        private Vector2 _movementInput;
        private bool _isGrounded;
        private bool _isPlayingParticles;
        
        // Components
        private InputHandler _inputHandler;
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        private GroundChecker _groundChecker;
        
        private void Start()
        {
            _inputHandler = InputHandler.Instance;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _groundChecker = GetComponentInChildren<GroundChecker>();
        }

        private void Update()
        {
            _movementInput = _inputHandler.MovementInput;
            _isGrounded = _groundChecker.IsGrounded;

            HandleRotation();
            HandleVisuals();
            
            if(_movementInput != Vector2.zero)
                Move(_movementInput.x);
        }

        private void Move(float input)
        {
            _rigidbody2D.linearVelocityX = input * movementSpeed;
        }

        private void HandleVisuals()
        {
            _animator.SetFloat("movementSpeed", _rigidbody2D.linearVelocityX);
            
            bool shouldEmit =
                _movementInput != Vector2.zero &&
                _isGrounded;

            if (shouldEmit && !_isPlayingParticles)
            {
                poofParticle.Play();
                _isPlayingParticles = true;
            }
            else if (!shouldEmit && _isPlayingParticles)
            {
                poofParticle.Stop();
                _isPlayingParticles = false;
            }
        }
        
        private void HandleRotation()
        {
            if (_rigidbody2D.linearVelocityX < 0)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }

            if (_rigidbody2D.linearVelocityX > 0)
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
        }
    }
}
