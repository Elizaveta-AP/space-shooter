using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Shell
{
    private Rigidbody2D _rb;
    protected override void Start()
    {
        base.Start();
        _rb = GetComponent<Rigidbody2D>();
        Speed = 2.0f;
        Damage = 5;
    }
    
    void FixedUpdate()
    {
        Move(_rb);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<Meteor>()){
            other.gameObject.GetComponent<Meteor>().TakeDamage(Damage);
        }
        Death();
    }
}
