using System;
using System.Collections;
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

            if (!s.lerpOnStart)
            {
                if (s.lerpUp)
                    StartCoroutine(LerpUp(s.source, s.volume));
                if (s.lerpDown)
                    StartCoroutine(LerpDown(s.source, s.StartLerpAt));
            }
        }
    }

    public IEnumerator LerpDown(AudioSource _source, float _waitTime)
    {
        yield return new WaitForSeconds(_waitTime);

        while (_source.volume > 0)
        {
            _source.volume -= Time.deltaTime * 0.3f;
            yield return null;
        }
    }

    public IEnumerator LerpUp(AudioSource _source, float _startVolume)
    {
        _source.volume = 0;

        while (_source.volume < _startVolume)
        {
            _source.volume += Time.deltaTime * 0.3f;
            yield return null;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s.lerpOnStart)
        {
            StartCoroutine(LerpUp(s.source, s.volume));
            StartCoroutine(LerpDown(s.source, s.StartLerpAt));
        }

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

    public bool lerpOnStart;
    public bool lerpUp;
    public bool lerpDown;
    public float StartLerpAt;
}

