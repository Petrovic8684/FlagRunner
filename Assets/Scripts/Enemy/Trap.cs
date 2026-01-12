using UnityEngine;
using System.Collections;

public class Trap : DamageDealer
{
    [SerializeField] private float damageCooldown = 1f;
    private bool canDamage = true;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!canDamage) return;

        if (!other.TryGetComponent(out IDamageable target)) return;

        ApplyDamage(target);
        StartCoroutine(DamageCooldown());
    }

    private IEnumerator DamageCooldown()
    {
        canDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }
}
