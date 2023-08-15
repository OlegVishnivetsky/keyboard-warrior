using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [Header("MAX VOLUME PARAMETERS")]
    [SerializeField, Range(0f, 1f)] private float maxMusicVolume;
    [SerializeField, Range(0f, 1f)] private float maxSoundEffectsVolume;

    [Header("SLIDER COMPONENTS")]
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider soundEffectsVolumeSlider;

    private void Start()
    {
        musicVolumeSlider.maxValue = maxMusicVolume;
        soundEffectsVolumeSlider.maxValue = maxSoundEffectsVolume;

        musicVolumeSlider.value = AudioController.Instance.GetMusicAudioSourceVolume();
        soundEffectsVolumeSlider.value = AudioController.Instance.GetSoundEffectsAudioSourceVolume();

        musicVolumeSlider.onValueChanged.AddListener(MusicVolumeSlider_OnValueChanged);
        soundEffectsVolumeSlider.onValueChanged.AddListener(SoundEffectsVolumeSlider_OnValueChanged);
    }

    private void MusicVolumeSlider_OnValueChanged(float value)
    {
        AudioController.Instance.SetMusicAudioSourceVolume(value);
    }

    private void SoundEffectsVolumeSlider_OnValueChanged(float value)
    {
        AudioController.Instance.SetSoundEffectsAudioSourceVolume(value);
    }
}