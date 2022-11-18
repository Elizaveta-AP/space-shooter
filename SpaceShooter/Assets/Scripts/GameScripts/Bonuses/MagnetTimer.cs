using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagnetTimer : MonoBehaviour
{
    [SerializeField] private GameObject _image, _slider;
    [SerializeField] private Slider _timeSlider;
    [SerializeField] private GameObject _magnet;
    private float _timeLeft;
    
    void Start()
    {
        
    }


    public void StartTimerCoroutine(float time)
    {
        if (_magnet.activeInHierarchy) { StopAllCoroutines(); }
        StartCoroutine(StartTimer(time));
    }

    
    private IEnumerator StartTimer(float time)
    {
        _image.SetActive(true);
        _slider.SetActive(true);

        if (!_magnet.activeInHierarchy) { _magnet.SetActive(true); }

        _timeLeft = time;

        while (_timeLeft > 0) 
        {
            _timeLeft -= Time.deltaTime;

            _timeSlider.value = _timeLeft / time;

            yield return null;
        }

        _magnet.SetActive(false);

        _image.SetActive(false);
        _slider.SetActive(false);
    }
}
