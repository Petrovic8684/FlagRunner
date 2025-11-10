using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    private bool isDeadly = true;

    private void OnTriggerStay(Collider other)
    {
        if (!isDeadly || other.gameObject.tag != "Player") return;

        other.GetComponent<PlayerHealth>()?.TakeDamage();
    }

    public void PlaySound() => sound.Play();

    public void SetDeadly() => isDeadly = true;
    public void SetNotDeadly() => isDeadly = false;
}
