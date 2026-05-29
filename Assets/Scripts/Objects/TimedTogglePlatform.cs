using UnityEngine;

namespace Objects
{
    public class TimedTogglePlatform : ToggleableObject
    {
        [SerializeField] private ToggleTimerConfig config;

        private float _timer;

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= config.interval)
            {
                _timer = 0;
                Toggle();
            }
        }
    }
}