using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserTimer : MonoBehaviour
{
    [SerializeField] private Slider _timeSlider;
    [SerializeField] private GameObject _laser;
    private Transform _parentTransform;
    private float _timer, _fillingTime, _workTime;
    private enum State {IsCharging, IsCharged, IsWorking};
    private State _state;

    private void Start() 
    {
        _parentTransform = GameObject.Find("Player").GetComponent<Transform>();

        _fillingTime = GameSettings.CurrentSettings.GetLaserLoadTime();
        _workTime = GameSettings.CurrentSettings.GetLaserWorkTime();

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
        _laser.SetActive(true);

        _timer = _workTime;

        while (_timer > 0) 
        {
            _timer -= Time.deltaTime;

            _timeSlider.value = _timer / _workTime;

            yield return null;
        }

        StartCoroutine(_laser.transform.GetComponent<Laser>().DestroyLaser());

        _state = State.IsCharging;

        StartCoroutine(FillEnergy());
    }
}
