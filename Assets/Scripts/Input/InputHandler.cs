using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler Instance { get; private set; }
        
        // ? Variables
        private Vector2 _movementInput;
        public Vector2 MovementInput => _movementInput;

        // ? Events
        public Action OnJump;

        // ? Components
        private InputAction _inputAction;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
            _inputAction = new InputAction();
        }

        public void OnMoveInput(InputAction.CallbackContext context)
        {
            _movementInput = context.ReadValue<Vector2>();
        }

        public void OnJumpInput(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnJump?.Invoke();
            }
        }
    }
}