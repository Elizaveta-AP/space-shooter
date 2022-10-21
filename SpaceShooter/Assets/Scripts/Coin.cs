using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    private float _speed;
    private Rigidbody2D _rb;
    private Transform _transform;
    private TMP_Text _coinText;
    private static int _coinsCount;
    void Start()
    {
        _speed = 2;
        _rb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _coinText = (GameObject.Find("CoinsText").GetComponent<TMP_Text>());
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_transform.position - new Vector3 (_speed, 0, 0) * Time.fixedDeltaTime);
        
        if (_transform.position.x < -10) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
            _coinsCount += 1;
            _coinText.text = $"{_coinsCount}";
            Destroy(this.gameObject);
        }
    }
}
