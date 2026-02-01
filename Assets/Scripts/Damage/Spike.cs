using UnityEngine;

public class Spike : DamageDealer
{
    private void Start()
    {
        AudioManager.Instance.PlayNoOverlap3D(SoundType.Spike, transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") || !other.TryGetComponent(out IDamageable target)) return;

        ApplyDamage(target);
    }
}
