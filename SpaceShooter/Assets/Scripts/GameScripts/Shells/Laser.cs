using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private BoxCollider2D _collider;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer, _backgroundRenderer;
    private float _length, _deltaLength, _speed; //
    private int _damage;
    private IEnumerator _updateCoroutine;


    void OnEnable()
    {
        _collider = GetComponent<BoxCollider2D>();
        _transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _backgroundRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        _damage = GameSettings.CurrentSettings.GetLaserDamage();

        _speed = 15;

        _updateCoroutine = UpdateLaser();

        StartCoroutine(InstantiateLaser());
    }

    IEnumerator InstantiateLaser()
    {
        _deltaLength = 8.8f - _transform.position.x;

        while(Mathf.Abs(_deltaLength)>0.1f)
        {        
            _length = 8.8f - _transform.position.x;
            _deltaLength = _length - _spriteRenderer.size.y;

            Vector2 size = _spriteRenderer.size + new Vector2 (0, _deltaLength).normalized * _speed * Time.deltaTime;

            _spriteRenderer.size = size;
            _backgroundRenderer.size = size;

            _collider.size = size;

            _collider.offset = new Vector2 (0, size.y/2);

            yield return null;
        }
        StartCoroutine(_updateCoroutine);
    }

    IEnumerator UpdateLaser()
    {
        while(true)
        {
            _length = 8.8f - _transform.position.x;

            Vector2 size = new Vector2 (0.26f, _length);

            _spriteRenderer.size = size;
            _backgroundRenderer.size = size;

            _collider.size = size;

            _collider.offset = new Vector2 (0, size.y/2);

            yield return null;
        }
    }

    public IEnumerator DestroyLaser()
    {
        StopCoroutine(_updateCoroutine);

        while(_length > 0.1f)
        {
            Vector2 size = _spriteRenderer.size - new Vector2 (0, 1) * _speed * Time.deltaTime;

            _length = size.y;

            _spriteRenderer.size = size;
            _backgroundRenderer.size = size;

            _collider.size = size;

            _collider.offset = new Vector2 (0, size.y/2);

            yield return null;
        }
        gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.tag == "Enemy" || other.tag == "Meteor")
        {
            other.gameObject.GetComponent<SolidObject>().TakeDamage(_damage);
        }
    }
}
