using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Current;
    [SerializeField] private AudioMixerGroup _mixer;
    
    void Start()
    {
        Current = this;

        
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
            SetEffectsVolume(PlayerPrefs.GetFloat("EffectsVolume"));
        }
        else
        {
            SetMusicVolume(0.5f);
            SetEffectsVolume(0.5f);
        }
    }

    public void SetMusicVolume(float value)
    {
        _mixer.audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }


    public void SetEffectsVolume(float value)
    {
        _mixer.audioMixer.SetFloat("EffectsVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("EffectsVolume", value);
    }
}
