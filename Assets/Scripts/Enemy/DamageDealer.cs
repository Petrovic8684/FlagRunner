using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    private bool isDeadly = true;

    public void SetDeadly() => isDeadly = true;
    public void SetNotDeadly() => isDeadly = false;

    public void PlaySound() => sound?.Play();

    protected void ApplyDamage(IDamageable target)
    {
        if (!isDeadly) return;
        target.LoseLife();
    }
}
