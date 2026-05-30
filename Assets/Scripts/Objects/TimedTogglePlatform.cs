using FMODUnity;
using Managers;
using UnityEngine;

namespace Objects
{
    public class TimedTogglePlatform : ToggleableObject
    {
        [SerializeField] private ToggleTimerConfig config;
        [SerializeField] private EventReference bellSFX;

        private float _timer;

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= config.interval)
            {
                _timer = 0;
                SoundManager.Instance.PlayOneShot(
                bellSFX,
                transform.position
                );
            
                Toggle();
            }
        }
    }
}