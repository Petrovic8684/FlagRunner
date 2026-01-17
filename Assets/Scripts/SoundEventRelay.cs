using UnityEngine;

public class SoundEventRelay : MonoBehaviour
{
    [SerializeField] private SoundType soundType;

    public void Play() => AudioManager.Instance.Play(soundType);
    public void PlayNoOverlap() => AudioManager.Instance.PlayNoOverlap(soundType);
    public void PlayNoOverlap3D() => AudioManager.Instance.PlayNoOverlap3D(soundType, transform.position);
}