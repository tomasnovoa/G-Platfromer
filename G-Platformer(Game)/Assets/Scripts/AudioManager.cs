using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Volume Settings")]
    [Range(0f, 1f)] public float musicVolume = 1f;
    [Range(0f, 1f)] public float sfxVolume = 1f;

    [Header("Sound Effects")]
    public List<SoundEffect> soundEffects = new List<SoundEffect>();

    [Header("Music Tracks")]
    public List<MusicTrack> musicTracks = new List<MusicTrack>();

    // Diccionarios para acceso rápido
    private Dictionary<string, AudioClip> sfxDictionary;
    private Dictionary<string, AudioClip> musicDictionary;

    [System.Serializable]
    public class SoundEffect
    {
        public string name;
        public AudioClip clip;
    }

    [System.Serializable]
    public class MusicTrack
    {
        public string name;
        public AudioClip clip;
    }

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Inicializa diccionarios
        sfxDictionary = new Dictionary<string, AudioClip>();
        foreach (var sfx in soundEffects)
        {
            if (!sfxDictionary.ContainsKey(sfx.name))
                sfxDictionary.Add(sfx.name, sfx.clip);
        }

        musicDictionary = new Dictionary<string, AudioClip>();
        foreach (var track in musicTracks)
        {
            if (!musicDictionary.ContainsKey(track.name))
                musicDictionary.Add(track.name, track.clip);
        }
    }

    private void Start()
    {
        AudioManager.Instance.PlayMusic("Musica");
        ApplyVolumeSettings();
    }
    private void Update()
    {
        ApplyVolumeSettings();
    }
    #region Volume Control

    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        if (musicSource != null)
            musicSource.volume = musicVolume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        if (sfxSource != null)
            sfxSource.volume = sfxVolume;
    }

    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public float GetSFXVolume()
    {
        return sfxVolume;
    }

    public void ApplyVolumeSettings()
    {
        SetMusicVolume(musicVolume);
        SetSFXVolume(sfxVolume);
    }

    #endregion

    #region Play SFX

    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip, sfxVolume);
        }
    }

    public void PlaySFX(string name)
    {
        if (sfxSource != null && sfxDictionary.ContainsKey(name))
        {
            sfxSource.PlayOneShot(sfxDictionary[name], sfxVolume);
        }
        else
        {
            Debug.LogWarning($"Sound effect '{name}' not found in AudioManager.");
        }
    }

    #endregion

    #region Music Control

    public void PlayMusic(string name, bool loop = true)
    {
        if (musicSource != null && musicDictionary.ContainsKey(name))
        {
            musicSource.clip = musicDictionary[name];
            musicSource.loop = loop;
            musicSource.volume = musicVolume;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning($"Music track '{name}' not found in AudioManager.");
        }
    }

    public void StopMusic()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }
    }

    public void PauseMusic()
    {
        if (musicSource != null)
        {
            musicSource.Pause();
        }
    }

    public void ResumeMusic()
    {
        if (musicSource != null)
        {
            musicSource.UnPause();
        }
    }

    #endregion
}