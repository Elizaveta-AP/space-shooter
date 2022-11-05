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
        MyTag = gameObject.tag;
        if (MyTag == "player")
        {
            Speed = GameSettings.CurrentSettings.GetBulletSpeed();
            Damage = GameSettings.CurrentSettings.GetBulletDamage();
        }
        else
        {
            Speed = GameDifficulty.CurrentDifficulty._enemyBulletSpeed;
            Damage = GameDifficulty.CurrentDifficulty._enemyBulletDamage;
        }
        base.Start();
    }
    
    void FixedUpdate()
    {
        Move(_rb);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        string otherTag = other.gameObject.tag;

        if (otherTag == "Shield") { Death(); }

        else if (otherTag != MyTag)
        {
            other.gameObject.GetComponent<SolidObject>().TakeDamage(Damage);
            Death();
        }
    }
}
