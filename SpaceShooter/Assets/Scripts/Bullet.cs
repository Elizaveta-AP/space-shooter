using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Shell
{
    
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _speed = 2.0f;
    }

    
    void FixedUpdate()
    {
        Move(_rb);
    }
}
