using UnityEngine;

namespace Objects
{
    public class ToggleableObject : MonoBehaviour
    {
        [Header("Object Settings")]
        [SerializeField] private bool initialState = true;
        [SerializeField] private float opacityWhenInactive = 0.1f;

        // Variables
        protected bool IsActive;

        // Components
        private Collider2D _collider;
        private SpriteRenderer _spriteRenderer;

        protected virtual void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        protected virtual void OnEnable()
        {
            // TODO: Subscribe events using Toggle function
        }

        protected virtual void OnDisable()
        {
            // TODO: Unsubscribe events using Toggle function
        }

        protected virtual void Start()
        {
            SetState(initialState);
        }

        protected virtual void Toggle()
        {
            SetState(!IsActive);
        }

        protected virtual void SetState(bool state)
        {
            IsActive = state;
            _collider.enabled = IsActive;

            // Visuals
            if (_spriteRenderer != null)
            {
                Color currentColor = _spriteRenderer.color;
                currentColor.a = IsActive ? 1.0f : opacityWhenInactive;
                _spriteRenderer.color = currentColor;
            }
        }
    }
}
