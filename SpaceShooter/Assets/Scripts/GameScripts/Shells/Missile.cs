using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Shell
{
    [SerializeField] private GameObject _explosion;
    protected override void Start()
    {
        base.Start();

        Speed = 10;
        Damage = 0;
    }

    void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Enemy" || other.tag == "Meteor")
        {
            Instantiate(_explosion, ThisTransform.position, Quaternion.Euler(0,0,0));
            Death();
        }
    }
}
