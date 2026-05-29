using Input;
using UnityEngine;

namespace Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField]  private float movementSpeed = 5f;
        
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
            HandleAnimation();
            
            if(_movementInput != Vector2.zero)
                Move(_movementInput.x);
        }

        private void Move(float input)
        {
            _rigidbody2D.linearVelocityX = input * movementSpeed;
        }

        private void HandleAnimation()
        {
            if (_rigidbody2D.linearVelocity.x > 0.01 || _rigidbody2D.linearVelocity.x < -0.01)
            {
                
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
