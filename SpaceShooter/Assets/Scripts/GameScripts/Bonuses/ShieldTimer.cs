using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class ShieldTimer : MonoBehaviour
{
    [SerializeField] private GameObject _image, _slider;
    [SerializeField] private Slider _timeSlider;
    [SerializeField] private GameObject _shield;
    private GameObject _currentShield;
    private Transform _parentTransform;
    private float _timeLeft;

    private void Start() 
    {
        _parentTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    public void StartTimerCoroutine(float time)
    {
        if (_currentShield != null) { StopAllCoroutines(); }
        StartCoroutine(StartTimer(time));
    }

    
    private IEnumerator StartTimer(float time)
    {
        _image.SetActive(true);
        _slider.SetActive(true);

        if (_currentShield == null) { _currentShield = Instantiate(_shield, _parentTransform); }

        _timeLeft = time;

        while (_timeLeft > 0) 
        {
            _timeLeft -= Time.deltaTime;

            _timeSlider.value = _timeLeft / time;

            yield return null;
        }

        Destroy(_currentShield);
        _currentShield = null;

        _image.SetActive(false);
        _slider.SetActive(false);
    }
}
