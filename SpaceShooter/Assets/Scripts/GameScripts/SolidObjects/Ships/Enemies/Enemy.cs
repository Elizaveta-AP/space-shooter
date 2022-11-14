using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Ship
{
    [SerializeField] private ParticleSystem _destruction;
    private Rigidbody2D _rb;
    private int _startSpeed = 5;
    protected override void Start()
    {
        Speed = _startSpeed;
        ShootDelay = GameDifficulty.CurrentDifficulty._enemiesShootDelay;
        MaxHealth = GameDifficulty.CurrentDifficulty._enemiesMaxHealth;
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ShootBullet());
        base.Start();
    }


    void FixedUpdate()
    {
        if (transform.position.x <= 8.3f && Speed == 5) { Speed = GameDifficulty.CurrentDifficulty._enemiesSpeed; }

        _rb.MovePosition(transform.position + new Vector3(-1, 0, 0) * Speed * Time.fixedDeltaTime);
        
        if (transform.position.x < -10) base.Death();
    }

    public override void Death()
    {
        Instantiate(_destruction, transform.position, Quaternion.Euler(0, 0, 0));
        Score.CurrentScore.SetScore(MaxHealth);
        BonusGeneration.Bonuses.Generation(transform.position);
        GameDifficulty.CurrentDifficulty.KillsCountUp(1);
        base.Death();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.layer == 6)
        {
            other.GetComponent<Player>().TakeDamage(CurrentHealth);
            base.Death();
            Instantiate(_destruction, transform.position, Quaternion.Euler(0, 0, 0));
        }
        else if (other.gameObject.tag == "Shield")
        {
            base.Death();
            Instantiate(_destruction, transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
}
