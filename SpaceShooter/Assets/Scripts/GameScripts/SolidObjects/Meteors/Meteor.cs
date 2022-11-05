using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : SolidObject
{
    private System.Random _random = new System.Random();
    private float _middleSpeed;
    private float _size, _speedRotation, _scale;
    private Rigidbody2D _rb;

    protected override void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _scale = _random.Next(40, 200) /100.0f;
        transform.localScale = new Vector3(_scale, _scale, _scale);

        _middleSpeed = GameDifficulty.CurrentDifficulty._meteorsMiddleSpeed;
        Speed = _random.Next(Mathf.CeilToInt(_middleSpeed*50), Mathf.CeilToInt(_middleSpeed*150))/100.0f;
        _speedRotation = _random.Next(-360, 360);

        MaxHealth = Mathf.RoundToInt(GameDifficulty.CurrentDifficulty._meteorsHealthMultplier * _scale);

        base.Start();
    }

    void FixedUpdate()
    {
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
        base.Death();
    }
    
}
