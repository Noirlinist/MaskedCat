using Player.Jump;
using UnityEngine;

namespace Objects
{
    public class Door : ToggleableObject
    {
        protected override void OnEnable()
        {
            base.OnEnable();

            SoulManager.Instance.OnAllSoulCollected += Toggle;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            SoulManager.Instance.OnAllSoulCollected -= Toggle;
        }

        private void Toggle(bool state)
        {
            gameObject.SetActive(!state);
        }
    }
}