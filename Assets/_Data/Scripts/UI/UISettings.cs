using UnityEngine;
using UnityEngine.UI;

public class UISettings : UIDisplay
{
    protected static UISettings instance;
    public static UISettings Instance => instance;

    [SerializeField] protected Slider musicSlider;
    [SerializeField] protected Slider sfxSlider;

    protected override void Awake()
    {
        base.Awake();
        if (UISettings.instance != null) Debug.LogWarning("Only 1 UISettings allow to axist");
        UISettings.instance = this;
    }
    protected override void Start()
    {
        base.Start();
        this.musicSlider.value = AudioManager.Instance.MusicSource.volume;
        this.sfxSlider.value = AudioManager.Instance.SfxSource.volume;

        this.musicSlider.onValueChanged.AddListener(this.ChangeMusicVolume);
        this.sfxSlider.onValueChanged.AddListener(this.ChangeSFXVolume);
    }

    protected void ChangeMusicVolume(float value)
    {
        AudioManager.Instance.SetMusicVolume(value);
    }

    protected void ChangeSFXVolume(float value)
    {
        AudioManager.Instance.SetSFXVolume(value);
    }
}