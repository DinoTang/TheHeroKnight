using UnityEngine;
using UnityEngine.UI;

public class UIAudioSettings : BaseBehavior
{
    [SerializeField] protected Slider musicSlider;
    [SerializeField] protected Slider sfxSlider;

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