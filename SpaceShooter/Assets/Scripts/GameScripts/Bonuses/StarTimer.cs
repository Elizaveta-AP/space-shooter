using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarTimer : MonoBehaviour
{
    [SerializeField] private GameObject _image, _slider;
    [SerializeField] private Slider _timeSlider;
    private float _timeLeft;


    public void StartTimerCoroutine(float time)
    {
        if (_slider.activeInHierarchy) { StopAllCoroutines(); }
        StartCoroutine(StartTimer(time));
    }

    
    private IEnumerator StartTimer(float time)
    {
        _image.SetActive(true);
        _slider.SetActive(true);

        Score.CurrentScore.SetScoreMultiplier(2);

        _timeLeft = time;

        while (_timeLeft > 0) 
        {
            _timeLeft -= Time.deltaTime;

            _timeSlider.value = _timeLeft / time;

            yield return null;
        }

        Score.CurrentScore.SetScoreMultiplier(1);

        _image.SetActive(false);
        _slider.SetActive(false);
    }
}
