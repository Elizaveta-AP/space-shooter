using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    private AudioSource _click;

    void Start()
    {
        _click = GameObject.Find("Click").GetComponent<AudioSource>();
    }

    public void PlayClick()
    {
        _click.Play();
    }
}
