using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;

    private void Awake()
    {
        instance = this;

        foreach (Sound s in sounds)
        {
            if (s.parent != null)
                s.source = s.parent.gameObject.AddComponent<AudioSource>();
            else
                s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.maxDistance = s.maxDistance;
            s.source.spatialBlend = s.spatialBlend;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s.dontCheckPlaying && s != null || !s.source.isPlaying && s != null)
            s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s.source.isPlaying && s != null)
            s.source.Stop();
    }
}

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    public Transform parent;

    [Range(0.1f, 1)]
    public float volume;

    [Range(0.1f, 3)]
    public float pitch;

    public bool loop = false;
    public bool dontCheckPlaying;

    [Range(0, 1), Header("3D settings")]
    public float spatialBlend;
    [Range(5, 100)]
    public float maxDistance;

    [HideInInspector] public AudioSource source;
}

