using Managers;
using UnityEngine;

namespace Audio
{
    public class MusicZoneTrigger : MonoBehaviour
    {
        [SerializeField] private float musicStateValue = 0.0f;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            SoundManager.Instance.ChangeMusicState(musicStateValue);
        }
    }
}