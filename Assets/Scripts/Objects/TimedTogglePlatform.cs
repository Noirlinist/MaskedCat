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
        private bool _hasPlayedWarning;

        private void Update()
        {
            _timer += Time.deltaTime;

            float timeToPlaySound = config.interval - config.soundAnticipationTime;

            if (_timer >= timeToPlaySound && !_hasPlayedWarning)
            {
                SoundManager.Instance.PlayOneShot(bellSFX, transform.position);
                _hasPlayedWarning = true;
            }

            if (_timer >= config.interval)
            {
                _timer = 0;
                _hasPlayedWarning = false;

                Toggle();
            }
        }
    }
}