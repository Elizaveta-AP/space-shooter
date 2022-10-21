using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Shell
{
    private Rigidbody2D _rb;
    protected override void Start()
    {
        forvard = transform.up;
        _rb = GetComponent<Rigidbody2D>();
        Speed = 5.0f;
        Damage = 5;
        MyTag = gameObject.tag;
        base.Start();
    }
    
    void FixedUpdate()
    {
        Move(_rb);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag != MyTag){
            other.gameObject.GetComponent<SolidObject>().TakeDamage(Damage);
        }
        Death();
    }
}
