using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneration : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    private float _frequency, _speed, _positionX;
    private Transform _transform;
    private System.Random _random = new System.Random();
    private Vector3 _nextPoint;
    void Start()
    {
        _transform = GetComponent<Transform>();
        _positionX = _transform.position.x;
        _frequency = 0.8f;
        _speed = 1;
        _nextPoint = new Vector3(_positionX, _random.Next(-350, 350)/100.0f, 0);
        StartCoroutine(Generation());
    }

    
    void FixedUpdate()
    {
        _transform.position = Vector3.MoveTowards(_transform.position, _nextPoint, Time.deltaTime * _speed);
        if (_transform.position == _nextPoint)
        {
            _nextPoint = new Vector3(_positionX, _random.Next(-350, 350)/100.0f, 0);
        }
    }

    IEnumerator Generation()
    {
        while(true)
        {
            Instantiate(_coin, _transform.position, Quaternion.Euler(0,0,0));
            yield return new WaitForSeconds(_frequency);
        }
    }
}
