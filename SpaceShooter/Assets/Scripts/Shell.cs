using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shell : MonoBehaviour
{
    protected float _speed = 2.0f;
    
    void Start()
    {
    }

    
    protected void Move(Rigidbody2D rb)
    {
        rb.MovePosition(transform.position + new Vector3 (_speed, 0, 0) * Time.fixedDeltaTime);
        if (transform.position.x > 11) Destroy(gameObject);
    }
}
