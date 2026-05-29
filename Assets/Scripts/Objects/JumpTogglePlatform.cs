using Player.Jump;

namespace Objects
{
    public class JumpTogglePlatform : ToggleableObject
    {
        protected override void OnEnable()
        {
            base.OnEnable();

            PlayerJump.OnPlayerJump += Toggle;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            PlayerJump.OnPlayerJump -= Toggle;
        }
    }
}