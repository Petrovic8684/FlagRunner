using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    private bool isDeadly = true;

    public void SetDeadly() => isDeadly = true;
    public void SetNotDeadly() => isDeadly = false;

    protected void ApplyDamage(IDamageable target)
    {
        if (!isDeadly) return;
        target.LoseLife();
    }
}