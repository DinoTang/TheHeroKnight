using System;
using UnityEngine;

public class AudioManager : BaseBehavior
{
    protected static AudioManager instance;
    public static AudioManager Instance => instance;

    private const string MUSIC_VOLUME_KEY = "MusicVolume";
    private const string SFX_VOLUME_KEY = "SFXVolume";

    [Header("Audio Clips")]
    [SerializeField] protected Sound[] musicSound;
    [SerializeField] protected Sound[] sfxSound;

    [Header("Audio Sources")]
    [SerializeField] protected AudioSource musicSource;
    [SerializeField] protected AudioSource sfxSource;
    [SerializeField] protected AudioSource footStepSource;
    [SerializeField] protected AudioSource monsterRunSource;
    [SerializeField] protected AudioSource axeSpinning;

    public AudioSource MusicSource => musicSource;
    public AudioSource SfxSource => sfxSource;
    public AudioSource FootStepSource => footStepSource;

    protected override void Awake()
    {
        base.Awake();

        if (AudioManager.instance != null && AudioManager.instance != this)
        {
            Destroy(gameObject);
            return;
        }

        AudioManager.instance = this;

        DontDestroyOnLoad(gameObject);

        this.LoadVolume();
    }

    protected override void Start()
    {
        base.Start();

        this.ClockMusic();
    }

    // =========================================================
    // VOLUME
    // =========================================================

    public void SetMusicVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);

        this.musicSource.volume = volume;

        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);

        this.sfxSource.volume = volume;
        this.footStepSource.volume = volume;
        this.monsterRunSource.volume = volume;
        this.axeSpinning.volume = volume;

        PlayerPrefs.SetFloat(SFX_VOLUME_KEY, volume);
        PlayerPrefs.Save();
    }

    protected void LoadVolume()
    {
        float musicVolume = PlayerPrefs.GetFloat(
            MUSIC_VOLUME_KEY,
            1f
        );

        float sfxVolume = PlayerPrefs.GetFloat(
            SFX_VOLUME_KEY,
            1f
        );

        this.musicSource.volume = musicVolume;

        this.sfxSource.volume = sfxVolume;
        this.footStepSource.volume = sfxVolume;
        this.monsterRunSource.volume = sfxVolume;
        this.axeSpinning.volume = sfxVolume;
    }

    // =========================================================
    // MUSIC
    // =========================================================

    public void ClockMusic()
    {
        this.musicSource.gameObject.SetActive(false);
    }

    public void OpenMusic()
    {
        this.musicSource.gameObject.SetActive(true);
    }

    public void PlayMusic(string name)
    {
        Sound sound = this.FindMusic(name);

        if (sound == null) return;

        this.musicSource.clip = sound.clip;
        this.musicSource.Play();
    }

    public void PlayMusic(string name, float volume)
    {
        Sound sound = this.FindMusic(name);

        if (sound == null) return;

        this.musicSource.clip = sound.clip;
        this.musicSource.volume = Mathf.Clamp01(volume);
        this.musicSource.Play();
    }

    public void StopMusic()
    {
        this.musicSource.Stop();
    }

    // =========================================================
    // NORMAL SFX
    // =========================================================

    public void PlaySFX(string name)
    {
        Sound sound = this.FindSFX(name);

        if (sound == null) return;

        this.sfxSource.PlayOneShot(sound.clip);
    }

    public void PlaySFX(string name, float volume)
    {
        Sound sound = this.FindSFX(name);

        if (sound == null) return;

        this.sfxSource.PlayOneShot(
            sound.clip,
            Mathf.Clamp01(volume)
        );
    }

    // =========================================================
    // MONSTER RUN
    // =========================================================

    public void PlayMonsterRun(string name)
    {
        Sound sound = this.FindSFX(name);

        if (sound == null) return;

        if (this.monsterRunSource.isPlaying)
            return;

        this.monsterRunSource.clip = sound.clip;
        this.monsterRunSource.loop = false;
        this.monsterRunSource.Play();
    }

    public void StopMonsterRun()
    {
        if (!this.monsterRunSource.isPlaying)
            return;

        this.monsterRunSource.Stop();
    }

    // =========================================================
    // AXE SPINNING
    // =========================================================

    public void PlayAxeSpinning(string name)
    {
        Sound sound = this.FindSFX(name);

        if (sound == null) return;

        if (this.axeSpinning.isPlaying)
            return;

        this.axeSpinning.clip = sound.clip;
        this.axeSpinning.loop = false;
        this.axeSpinning.Play();
    }

    public void StopAxeSpinning()
    {
        if (!this.axeSpinning.isPlaying)
            return;

        this.axeSpinning.Stop();
    }

    // =========================================================
    // FIND SOUND
    // =========================================================

    protected Sound FindMusic(string name)
    {
        return Array.Find(
            this.musicSound,
            sound => sound.soundName.ToString() == name
        );
    }

    protected Sound FindSFX(string name)
    {
        return Array.Find(
            this.sfxSound,
            sound => sound.soundName.ToString() == name
        );
    }
}