using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class ShieldTimer : MonoBehaviour
{
    [SerializeField] private GameObject _image, _slider;
    [SerializeField] private Slider _timeSlider;
    [SerializeField] private GameObject _shield;
    private Transform _parentTransform;
    private float _timeLeft;

    private void Start() 
    {
        _parentTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    public void StartTimerCoroutine(float time)
    {
        if (_shield.activeInHierarchy) { StopAllCoroutines(); }
        StartCoroutine(StartTimer(time));
    }

    
    private IEnumerator StartTimer(float time)
    {
        _image.SetActive(true);
        _slider.SetActive(true);

        if (!_shield.activeInHierarchy) { _shield.SetActive(true); }

        _timeLeft = time;

        while (_timeLeft > 0) 
        {
            _timeLeft -= Time.deltaTime;

            _timeSlider.value = _timeLeft / time;

            yield return null;
        }

        _shield.SetActive(false);

        _image.SetActive(false);
        _slider.SetActive(false);
    }
}
