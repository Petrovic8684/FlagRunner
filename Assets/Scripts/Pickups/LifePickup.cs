using UnityEngine;

public class LifePickup : Pickup
{
    protected override void ApplyEffect(Collider other)
    {
        if (!other.TryGetComponent(out IDamageable damageable)) return;

        damageable.GainLife();
    }
}
