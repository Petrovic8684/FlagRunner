using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    Score,
    Life,
    Death,
    Jump,
    Trap,
    Spike,
    LevelChange,
    MenuButton
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [System.Serializable]
    public class Sound
    {
        public SoundType type;
        public AudioSource source;
    }

    [SerializeField] private List<Sound> soundsList;

    private Dictionary<SoundType, AudioSource> soundsMap = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        RegisterSounds();
    }

    private void RegisterSounds()
    {
        foreach (var s in soundsList)
            if (!soundsMap.ContainsKey(s.type))
                soundsMap.Add(s.type, s.source);
    }

    public void Play(SoundType type)
    {
        if (!soundsMap.TryGetValue(type, out var source) || source.clip == null) return;

        source.PlayOneShot(source.clip);
    }

    public void PlayNoOverlap(SoundType type)
    {
        if (!soundsMap.TryGetValue(type, out var source)) return;

        source.Play();
    }

    public void PlayNoOverlap3D(SoundType type, Vector3 position)
    {
        if (!soundsMap.TryGetValue(type, out var source)) return;

        AudioSource copy = Instantiate(source, position, Quaternion.identity);
        copy.Play();

        if (source.loop) return;

        Destroy(copy.gameObject, copy.clip.length);
    }
}
