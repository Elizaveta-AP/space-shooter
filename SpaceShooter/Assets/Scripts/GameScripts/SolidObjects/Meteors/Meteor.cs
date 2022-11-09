using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : SolidObject
{
    [SerializeField] private ParticleSystem _destruction;
    private System.Random _random = new System.Random();
    private int _startSpeed = 5;
    private float _middleSpeed, _size, _speedRotation, _scale;
    private Rigidbody2D _rb;

    protected override void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _scale = _random.Next(40, 200) /100.0f;
        transform.localScale = new Vector3(_scale, _scale, _scale);

        _middleSpeed = GameDifficulty.CurrentDifficulty._meteorsMiddleSpeed;
        Speed = _startSpeed;
        _speedRotation = _random.Next(-360, 360);

        MaxHealth = Mathf.RoundToInt(GameDifficulty.CurrentDifficulty._meteorsHealthMultplier * _scale);

        base.Start();
    }

    void FixedUpdate()
    {
        if (transform.position.x <= (8.9f + _scale/2.0f) && Speed == 5) 
        { 
            Speed = _random.Next(Mathf.CeilToInt(_middleSpeed*50), Mathf.CeilToInt(_middleSpeed*150))/100.0f; 
        }

        _rb.MovePosition(transform.position - new Vector3 (Speed, 0, 0) * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation + _speedRotation * Time.fixedDeltaTime);
        
        if (transform.position.x < -11) base.Death();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string otherTag = other.gameObject.tag;
        
        if (otherTag == "Shield") { base.Death(); }

        else if (other.gameObject.GetComponent<Player>()) {
            base.Death();
            other.gameObject.GetComponent<Player>().TakeDamage(MaxHealth);
            }
    }
    public override void Death()
    {
        Score.CurrentScore.SetScore(MaxHealth);
        BonusGeneration.Bonuses.Generation(transform.position);
        GameDifficulty.CurrentDifficulty.KillsCountUp(0.5f);

        ParticleSystem particles = Instantiate(_destruction, transform.position, Quaternion.Euler(0, 0, 0));
        ParticleSystem.MainModule particleMain = particles.main;
        particleMain.startSize = new ParticleSystem.MinMaxCurve(_scale);


        base.Death();
    }
    
}
