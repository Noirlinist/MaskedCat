using FMODUnity;
using Managers;
using Player.Jump;
using UnityEngine;

namespace Objects
{
    public class JumpTogglePlatform : ToggleableObject
    {
        [SerializeField] private EventReference fogSFX;

        protected override void OnEnable()
        {
            base.OnEnable();

            PlayerJump.OnPlayerJump += Toggle;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            SoundManager.Instance.PlayOneShot(
                fogSFX,
                transform.position
            );
            PlayerJump.OnPlayerJump -= Toggle;
        }
    }
}