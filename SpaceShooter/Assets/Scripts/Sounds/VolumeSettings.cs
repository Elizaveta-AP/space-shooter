using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _musicSlider, _effectsSlider;

    private void Start() 
    {
        _musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        _effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume");
    }


    public void SetMusicSliderValue(float value)
    {
        AudioManager.Current.SetMusicVolume(value);
    }


    public void SetEffectsSliderValue(float value)
    {
        AudioManager.Current.SetEffectsVolume(value);
    }
}