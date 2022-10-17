using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MeteorController : MonoBehaviour
{
    System.Random _random = new System.Random();
    [SerializeField] private int _mediumSpeed;
    private float _size, _speed, _speedRotation, _scale;
    private Rigidbody2D _rb;

    void OnEnable()
    {
        _scale = _random.Next(40, 200) /100.0f;
        transform.localScale = new Vector3(_scale, _scale, _scale);
        _rb = GetComponent<Rigidbody2D>();
        _speed = _random.Next(_mediumSpeed*50, _mediumSpeed*150)/100.0f;
        _speedRotation = _random.Next(-360, 360);
    }

    void FixedUpdate()
    {
        _rb.MovePosition(transform.position - new Vector3 (_speed, 0, 0) * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation + _speedRotation * Time.fixedDeltaTime);
        
        if (transform.position.x < -11) Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") Destroy(gameObject);
    }
}
