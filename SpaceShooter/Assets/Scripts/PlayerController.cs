using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _bullet;
    private Rigidbody2D _rb;
    private Animator _leftFireAnim, _middleFireAnim, _rightFireAnim;
    private int _shootingDelay = 1;
    [SerializeField] private Transform _leftBullet, _rightBullet;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _leftFireAnim = this.gameObject.transform.Find("LeftFire").gameObject.GetComponent<Animator>();
        _rightFireAnim = this.gameObject.transform.Find("RightFire").gameObject.GetComponent<Animator>();
        _middleFireAnim = this.gameObject.transform.Find("MiddleFire").gameObject.GetComponent<Animator>();
        StartCoroutine(ShootBullet());
    }

    void FixedUpdate()
    {
        int velocityX = Mathf.RoundToInt(Input.GetAxis("Horizontal"));
        int velocityY = Mathf.RoundToInt(Input.GetAxis("Vertical"));
        _rb.velocity = transform.TransformDirection(new Vector3(velocityX, velocityY) * _speed);
        _leftFireAnim.SetInteger("VelocityY", velocityY);
        _rightFireAnim.SetInteger("VelocityY", velocityY);
        _middleFireAnim.SetInteger("VelocityX", velocityX);
    }
    IEnumerator ShootBullet(){
        while(true){
            yield return new WaitForSeconds(_shootingDelay);
            Instantiate(_bullet, _leftBullet.position, Quaternion.Euler(0, 0, -90));
            Instantiate(_bullet, _rightBullet.position, Quaternion.Euler(0, 0, -90));}
    }
}
