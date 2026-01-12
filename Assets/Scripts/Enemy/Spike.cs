using UnityEngine;

public class Spike : DamageDealer
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!other.TryGetComponent(out IDamageable target)) return;

        ApplyDamage(target);
    }
}
