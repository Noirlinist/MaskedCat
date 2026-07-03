using UnityEngine;
using FMODUnity;
using FMOD.Studio;

namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance { get; private set; }

        [Header("FMOD Event Reference")]
        [SerializeField] private EventReference globalMusicEvent;

        private EventInstance _musicInstance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            StartGlobalMusic();
        }

        private void StartGlobalMusic()
        {
            if (globalMusicEvent.IsNull) return;

            _musicInstance = RuntimeManager.CreateInstance(globalMusicEvent);
            _musicInstance.start();
        }

        public void ChangeMusicState(float stateValue)
        {
            if (!_musicInstance.isValid()) return;

            _musicInstance.setParameterByName("GameState", stateValue);
        }

        public void StopMusic()
        {
            if (_musicInstance.isValid())
            {
                _musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                _musicInstance.release();
            }
        }

        // =========================
        // SFX
        // =========================
        public void PlayOneShot(EventReference sound, Vector3 worldPosition = default)
        {
            if (sound.IsNull) return;
            RuntimeManager.PlayOneShot(sound, worldPosition);
        }
    }
}