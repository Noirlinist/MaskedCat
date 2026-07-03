using Player.Jump;
using UnityEngine;

namespace Objects
{
    public class Door : ToggleableObject
    {
        protected override void Start()
        {
            base.OnEnable();

            SoulManager.Instance.OnAllSoulCollected += Toggle;
        }

        protected void OnDestroy()
        {

            SoulManager.Instance.OnAllSoulCollected -= Toggle;
        }

        protected override void Toggle()
        {
            gameObject.SetActive(false);
        }
    }
}