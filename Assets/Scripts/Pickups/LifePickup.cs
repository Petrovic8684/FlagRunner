using UnityEngine;

public class LifePickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;

        other.GetComponent<PlayerHealth>()?.GainLife();
        Destroy(gameObject);
    }
}
