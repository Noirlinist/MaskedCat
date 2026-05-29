using System.Collections;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

namespace Managers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance { get; private set; }

        [Header("Music Settings")]
        [SerializeField] private float fadeDuration = 2f;

        // Variables
        private EventInstance _currentMusicInstance;
        private EventReference _currentMusic;

        private Coroutine _musicCoroutine;

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

        // =========================
        // SFX
        // =========================

        public void PlayOneShot(EventReference sound, Vector3 worldPosition = default)
        {
            RuntimeManager.PlayOneShot(sound, worldPosition);
        }

        // =========================
        // MUSIC
        // =========================

        public void PlayMusic(EventReference musicEvent)
        {
            // Prevent restarting same music
            if (_currentMusic.Guid == musicEvent.Guid)
                return;

            // Stop previous transition if exists
            if (_musicCoroutine != null)
            {
                StopCoroutine(_musicCoroutine);
            }

            _musicCoroutine = StartCoroutine(
                CrossfadeMusic(musicEvent)
            );
        }

        private IEnumerator CrossfadeMusic(EventReference newMusic)
        {
            EventInstance oldMusic = _currentMusicInstance;

            // Create new music instance
            EventInstance newMusicInstance =
                RuntimeManager.CreateInstance(newMusic);

            // Start muted
            newMusicInstance.setVolume(0f);
            newMusicInstance.start();

            float timer = 0f;

            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;

                float t = Mathf.Clamp01(timer / fadeDuration);

                // Fade in new music
                newMusicInstance.setVolume(t);

                // Fade out old music
                if (oldMusic.isValid())
                {
                    oldMusic.setVolume(1f - t);
                }

                yield return null;
            }

            // Cleanup old music
            if (oldMusic.isValid())
            {
                oldMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                oldMusic.release();
            }

            // Ensure full volume
            newMusicInstance.setVolume(1f);

            // Save new music
            _currentMusicInstance = newMusicInstance;
            _currentMusic = newMusic;
        }

        public void StopMusic()
        {
            if (_currentMusicInstance.isValid())
            {
                _currentMusicInstance.stop(
                    FMOD.Studio.STOP_MODE.ALLOWFADEOUT
                );

                _currentMusicInstance.release();
            }
        }
    }
}