using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrintPlayerCharacteristics : MonoBehaviour
{
    public static PrintPlayerCharacteristics PrintCharacteristics;
    private TMP_Text _shipSpeed, _shipHealth, _shootDelay, _bulletSpeed, _bulletDamage;
    
    void Start()
    {
        PrintCharacteristics= this;

        _shipSpeed = transform.Find("TextShipSpeed").GetComponent<TMP_Text>();
        _shipHealth = transform.Find("TextShipHealth").GetComponent<TMP_Text>(); 
        _shootDelay = transform.Find("TextShootDelay").GetComponent<TMP_Text>();
        _bulletSpeed = transform.Find("TextBulletSpeed").GetComponent<TMP_Text>();
        _bulletDamage = transform.Find("TextBulletDamage").GetComponent<TMP_Text>();

        SetAllTextes();
    }

    public void SetShipSpeedText()
    {
        _shipSpeed.text = "Скорость: " + GameSettings.CurrentSettings.GetSpeed();
    }

    public void SetShipHealthText()
    {
        _shipHealth.text = "Прочность: " + GameSettings.CurrentSettings.GetMaxHealth();
    }

    public void SetShootDelayText()
    {
        _shootDelay.text = "Скорость перезарядки: " + GameSettings.CurrentSettings.GetShootDelay();
    }

    public void SetBulletSpeedText()
    {
        _bulletSpeed.text = "Мощность: " + GameSettings.CurrentSettings.GetBulletSpeed();
    }

    public void SetBulletDamageText()
    {
        _bulletDamage.text = "Урон: " + GameSettings.CurrentSettings.GetBulletDamage();
    }

    public void SetAllTextes()
    {
        SetShipSpeedText();
        SetShipHealthText();
        SetShootDelayText();
        SetBulletSpeedText();
        SetBulletDamageText();
    }

}
