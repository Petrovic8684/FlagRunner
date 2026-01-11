using UnityEngine;

public class Spike : DamageDealer
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        ApplyDamage(other.GetComponent<PlayerHealth>());
    }
}