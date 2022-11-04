using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Ship
{
    private Rigidbody2D _rb;
    protected override void Start()
    {
        Speed = GameDifficulty.CurrentDifficulty._enemiesSpeed;
        ShootDelay = GameDifficulty.CurrentDifficulty._enemiesShootDelay;
        MaxHealth = GameDifficulty.CurrentDifficulty._enemiesMaxHealth;
        _rb = GetComponent<Rigidbody2D>();
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
        Score.CurrentScore.SetScore(MaxHealth);
        base.Death();
    }
}
