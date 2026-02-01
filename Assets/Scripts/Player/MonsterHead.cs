using UnityEngine;

public class MonsterHead : MonoBehaviour
{
    [SerializeField] GameObject monster;
    [SerializeField] ParticleSystem deathParticleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        AudioManager.Instance.Play(SoundType.Monster);
        deathParticleSystem.Play();

        Destroy(monster);
    }
}