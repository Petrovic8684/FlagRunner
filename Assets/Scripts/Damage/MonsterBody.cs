using UnityEngine;

public class MonsterBody : DamageDealer
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || !other.TryGetComponent(out IDamageable target)) return;

        ApplyDamage(target);
    }
}
