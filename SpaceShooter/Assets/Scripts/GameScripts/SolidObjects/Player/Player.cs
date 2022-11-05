using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Ship
{
    private Rigidbody2D _rb;
    private Animator _leftFireAnim, _middleFireAnim, _rightFireAnim, _damageAnim;
    [SerializeField] private Slider _slider;
    private AudioSource _loseAudio;
    private int velocityX, velocityY;

    protected override void Start()
    {
        Speed = GameSettings.CurrentSettings.GetSpeed();
        ShootDelay = GameSettings.CurrentSettings.GetShootDelay();
        MaxHealth = GameSettings.CurrentSettings.GetMaxHealth();

        _slider.value = 1;
        _rb = GetComponent<Rigidbody2D>();
        _loseAudio = this.gameObject.transform.Find("Lose").gameObject.GetComponent<AudioSource>();
        _leftFireAnim = this.gameObject.transform.Find("LeftFire").gameObject.GetComponent<Animator>();
        _rightFireAnim = this.gameObject.transform.Find("RightFire").gameObject.GetComponent<Animator>();
        _middleFireAnim = this.gameObject.transform.Find("MiddleFire").gameObject.GetComponent<Animator>();
        _damageAnim = this.gameObject.transform.Find("Damage").gameObject.GetComponent<Animator>();
        StartCoroutine(ShootBullet(-90));
        base.Start();
    }

    void FixedUpdate()
    {
        velocityX = Mathf.RoundToInt(Input.GetAxis("Horizontal"));
        velocityY = Mathf.RoundToInt(Input.GetAxis("Vertical"));
        _rb.MovePosition(transform.position + new Vector3(velocityX, velocityY, 0).normalized * Speed * Time.fixedDeltaTime);
        _leftFireAnim.SetInteger("VelocityY", velocityY);
        _rightFireAnim.SetInteger("VelocityY", velocityY);
        _middleFireAnim.SetInteger("VelocityX", velocityX);
    }

    public override void Death()
    {
        _loseAudio.Play();
        GameController.ThisGameController.GameOver();
        base.Death();
        SceneManager.LoadScene(0);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        float health = 1.0f*CurrentHealth/MaxHealth;
        _slider.value = health;
        _damageAnim.SetFloat("Health", health);
    }

    public void IncreaseHealth(int value)
    {
        CurrentHealth += value;
        if (CurrentHealth > MaxHealth) { CurrentHealth = MaxHealth; }
        
        float health = 1.0f*CurrentHealth/MaxHealth;
        _slider.value = health;
        _damageAnim.SetFloat("Health", health);
    }
}
