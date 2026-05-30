using UnityEngine;

public class Soul : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "PF_Player")
        {
            SoulManager.Instance.SoulCount += 1;
            Destroy(gameObject);
        }
    }
}
