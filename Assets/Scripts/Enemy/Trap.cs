using UnityEngine;

public class Trap : DamageDealer
{
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        ApplyDamage(other.GetComponent<PlayerHealth>());
    }
}