using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserTimer : MonoBehaviour
{
    [SerializeField] private Slider _timeSlider;
    [SerializeField] private GameObject _laser;
    private GameObject _currentLaser;
    private Transform _parentTransform;
    private float _timer, _fillingTime, _workTime;
    private enum State {IsCharging, IsCharged, IsWorking};
    private State _state;

    private void Start() 
    {
        _parentTransform = GameObject.Find("Player").GetComponent<Transform>();

        _fillingTime = 180;
        _workTime = 10;

        _state = State.IsCharging;
        StartCoroutine(FillEnergy());
    }

    private IEnumerator FillEnergy()
    {
        _timer = 0;

        while(_timer < _fillingTime)
        {
            _timer += Time.deltaTime;
            
            _timeSlider.value = _timer / _fillingTime;

            yield return null;
        }

        _state = State.IsCharged;
        StartCoroutine(CheckForStartWork());
    }

    private IEnumerator CheckForStartWork()
    {
        while(_state == State.IsCharged)
        {
            if (Input.GetButtonUp("Fire1")) 
            {
                _state = State.IsWorking;
                StartCoroutine(StartWork());
            }
            yield return null;
        }
    }

    
    private IEnumerator StartWork()
    {
        _currentLaser = Instantiate(_laser, _parentTransform);

        _timer = _workTime;

        while (_timer > 0) 
        {
            _timer -= Time.deltaTime;

            _timeSlider.value = _timer / _workTime;

            yield return null;
        }

        StartCoroutine(_currentLaser.transform.GetComponent<Laser>().DestroyLaser());
        _currentLaser = null;

        _state = State.IsCharging;

        StartCoroutine(FillEnergy());
    }
}
