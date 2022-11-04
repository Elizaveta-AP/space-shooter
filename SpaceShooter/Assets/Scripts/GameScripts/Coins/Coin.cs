using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float _speed;
    private Rigidbody2D _rb;
    private Transform _transform;
    void Start()
    {
        _speed = 2;
        _rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_transform.position - new Vector3 (_speed, 0, 0) * Time.fixedDeltaTime);
        
        if (_transform.position.x < -10) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
            CoinsCount.Count.TakeCoin();
            Destroy(this.gameObject);
        }
    }

}
