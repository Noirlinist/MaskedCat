using UnityEngine;

namespace Objects
{
    [CreateAssetMenu(
        fileName = "ToggleTimerConfig",
        menuName = "Configs/Toggle Timer Config"
    )]
    public class ToggleTimerConfig : ScriptableObject
    {
        [Min(0.1f)]
        public float interval = 2f;
    }
}