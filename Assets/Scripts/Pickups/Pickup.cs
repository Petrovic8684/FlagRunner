using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        ApplyEffect(other);
        Destroy(gameObject);
    }

    protected abstract void ApplyEffect(Collider player);
}