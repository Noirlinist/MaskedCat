using UnityEngine;

namespace Objects
{
    [CreateAssetMenu(
        fileName = "ToggleTimerConfig",
        menuName = "Configs/Toggle Timer Config"
    )]
    public class ToggleTimerConfig : ScriptableObject
    {
        [Min(0.1f)] public float interval = 2f;

        [Tooltip("Time in seconds before the sound plays when the toggle is activated.")]
        [Min(0f)] public float soundAnticipationTime = 0.5f;
    }
}