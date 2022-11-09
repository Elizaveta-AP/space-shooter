using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonsActive : MonoBehaviour
{
    private Button _buttonShipSpeed, _buttonShipHealth, _buttonShootDelay, _buttonBulletSpeed, _buttonBulletDamage;
    void Start()
    {
        _buttonShipSpeed = transform.Find("ButtonShipSpeed").GetComponent<Button>();
        _buttonShipHealth = transform.Find("ButtonShipHealth").GetComponent<Button>();
        _buttonShootDelay = transform.Find("ButtonShootDelay").GetComponent<Button>();
        _buttonBulletSpeed = transform.Find("ButtonBulletSpeed").GetComponent<Button>();
        _buttonBulletDamage = transform.Find("ButtonBulletDamage").GetComponent<Button>();
        
        SetAllButtensActive();
    }

    private void SetAllButtensActive()
    {
        SetActiveButtonShipSpeed();
        SetActiveButtonShipHealth();
        SetActiveButtonShootDelay();
        SetActiveButtonBulletSpeed();
        SetActiveButtonBulletDamage();
    }

    public void SetActiveButtonShipSpeed()
    {
        if (GameSettings.CurrentSettings.GetSpeed() >= 15) { _buttonShipSpeed.interactable = false; }
    }

    public void SetActiveButtonShipHealth()
    {
        if (GameSettings.CurrentSettings.GetMaxHealth() >= 1000) { _buttonShipHealth.interactable = false; }
    }

    public void SetActiveButtonShootDelay()
    {
        if (GameSettings.CurrentSettings.GetShootDelay() <= 0.2f) { _buttonShootDelay.interactable = false; }
    }

    public void SetActiveButtonBulletSpeed()
    {
        if (GameSettings.CurrentSettings.GetBulletSpeed() >= 30) { _buttonBulletSpeed.interactable = false; }
    }

    public void SetActiveButtonBulletDamage()
    {
        if (GameSettings.CurrentSettings.GetBulletDamage() >= 100) { _buttonBulletDamage.interactable = false; }
    }
}
