using FMODUnity;
using Managers;
using UnityEngine;

namespace Audio
{
    public class MusicZoneTrigger : MonoBehaviour
    {
        [SerializeField] private EventReference musicEvent;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            SoundManager.Instance.PlayMusic(musicEvent);
        }
    }
}