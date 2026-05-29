using UnityEngine;

namespace Tools
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float checkRadius = 0.2f;

        public bool IsGrounded { get; private set; }

        private void Update()
        {
            IsGrounded = Physics2D.OverlapCircle(
                transform.position,
                checkRadius,
                groundLayer
            );
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;

            Gizmos.DrawWireSphere(
                transform.position,
                checkRadius
            );
        }
    }
}