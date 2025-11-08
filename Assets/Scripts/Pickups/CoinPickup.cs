using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;

        other.GetComponent<PlayerScore>()?.AddScore();
        Destroy(gameObject);
    }
}
