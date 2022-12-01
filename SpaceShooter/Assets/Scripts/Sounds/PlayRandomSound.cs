using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] Sounds;
    private AudioSource _audioSource;
    private System.Random _random = new System.Random();

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        int soundNumber = _random.Next(Sounds.Length);
        float pitchValue = _random.Next(5, 15) / 10.0f;

        _audioSource.pitch = pitchValue;
        _audioSource.PlayOneShot(Sounds[soundNumber]);
    }
}
