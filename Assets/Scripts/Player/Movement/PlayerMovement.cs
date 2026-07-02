using Input;
using UnityEngine;
using Tools;

namespace Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float movementSpeed = 5f;
        [Range(0f, 1f)][SerializeField] private float lerpAmount = 0.2f;

        // Variables
        private Vector2 _movementInput;

        // Components
        private InputHandler _inputHandler;
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;

        private void Start()
        {
            _inputHandler = InputHandler.Instance;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _movementInput = _inputHandler.MovementInput;

            HandleRotation();
            HandleVisuals();
        }

        private void FixedUpdate()
        {
            Move(_movementInput.x);
        }

        private void Move(float input)
        {
            float targetSpeed = input * movementSpeed;

            _rigidbody2D.linearVelocityX = Mathf.Lerp(_rigidbody2D.linearVelocityX, targetSpeed, lerpAmount);
        }

        private void HandleVisuals()
        {
            _animator.SetFloat("movementSpeed", _rigidbody2D.linearVelocityX);
        }

        private void HandleRotation()
        {
            if (_movementInput.x < 0)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
            else if (_movementInput.x > 0)
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
        }
    }
}
