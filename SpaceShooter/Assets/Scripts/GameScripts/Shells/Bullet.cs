using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Shell
{
    private Rigidbody2D _rb;

    protected override void Start()
    {
        base.Start();
        MyTag = gameObject.tag;
        if (MyTag == "Player")
        {
            Speed = GameSettings.CurrentSettings.GetBulletSpeed();
            Damage = GameSettings.CurrentSettings.GetBulletDamage();
        }
        else
        {
            Speed = GameDifficulty.CurrentDifficulty._enemyBulletSpeed;
            Damage = GameDifficulty.CurrentDifficulty._enemyBulletDamage;
        }
    }
    
    void FixedUpdate()
    {
        Move();
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
