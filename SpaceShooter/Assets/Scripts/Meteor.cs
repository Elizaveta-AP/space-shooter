using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : SolidObject
{
    private System.Random _random = new System.Random();
    [SerializeField] private int _mediumSpeed;
    private float _size, _speedRotation, _scale;
    private Rigidbody2D _rb;

    protected override void Start()
    {
        base.Start();
        _scale = _random.Next(40, 200) /100.0f;
        transform.localScale = new Vector3(_scale, _scale, _scale);
        _rb = GetComponent<Rigidbody2D>();
        Speed = _random.Next(_mediumSpeed*50, _mediumSpeed*150)/100.0f;
        _speedRotation = _random.Next(-360, 360);
        MaxHealth = Mathf.RoundToInt(10 * _scale);
    }

    void FixedUpdate()
    {
        _rb.MovePosition(transform.position - new Vector3 (Speed, 0, 0) * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation + _speedRotation * Time.fixedDeltaTime);
        
        if (transform.position.x < -11) base.Death();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>()) {
            base.Death();
            other.gameObject.GetComponent<Player>().TakeDamage(MaxHealth);
            }
    }
    public override void Death()
    {
        Score.SetScore(MaxHealth);
        base.Death();
    }
    
}
