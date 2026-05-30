using UnityEngine;

public class Soul : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "PF_Player")
        {
            SoulManager.Instance.SoulCount++;
            Debug.Log(SoulManager.Instance.SoulCount);
            Destroy(gameObject);
        }
    }
}
