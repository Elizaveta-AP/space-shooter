using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Ship
{
    private Rigidbody2D _rb;
    protected override void Start()
    {
        Speed = 0.2f;
        ShootDelay = 2f;
        MaxHealth = 10;
        _rb = GetComponent<Rigidbody2D>();
        //_damageAnim = this.gameObject.transform.Find("Damage").gameObject.GetComponent<Animator>();
        StartCoroutine(ShootBullet(90));
        base.Start();
    }


    void FixedUpdate()
    {
        _rb.MovePosition(transform.position + new Vector3(-1, 0, 0) * Speed * Time.fixedDeltaTime);
        if (transform.position.x < -10) base.Death();
    }

    public override void Death()
    {
        Score.SetScore(MaxHealth);
        base.Death();
    }
}
