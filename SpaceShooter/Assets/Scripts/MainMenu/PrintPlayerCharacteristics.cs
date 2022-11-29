using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrintPlayerCharacteristics : MonoBehaviour
{
    public static PrintPlayerCharacteristics PrintCharacteristics;
    [SerializeField] private TMP_Text _shipSpeed, _shipHealth, _gunsCount, _shootDelay, _bulletSpeed, _bulletDamage,
    _laserWorkTime, _laserReloadTime, _laserDamage, _missilesCount, _missileDamage, _missileDamageDiametr,
    _bonusMagnet, _bonusShield, _bonusStar, _bonusPill;
    
    void Start()
    {
        PrintCharacteristics= this;

        SetAllTextes();
    }

    public void SetShipSpeedText()
    {
        _shipSpeed.text = "Скорость: " + GameSettings.CurrentSettings.GetSpeed();
    }

    public void SetShipHealthText()
    {
        _shipHealth.text = "Здоровье: " + GameSettings.CurrentSettings.GetMaxHealth();
    }

    public void SetGunsCountText()
    {
        int gunsCount;

        if(GameSettings.CurrentSettings.GetHasAdditionalGuns()) { gunsCount = 4; }
        else { gunsCount = 2; }

        _gunsCount.text = "Количество пушек: " + gunsCount;
    }
    
    public void SetShootDelayText()
    {
        _shootDelay.text = "Время перезарядки: " + GameSettings.CurrentSettings.GetShootDelay() + " c.";
    }

    public void SetBulletSpeedText()
    {
        _bulletSpeed.text = "Мощность: " + GameSettings.CurrentSettings.GetBulletSpeed();
    }

    public void SetBulletDamageText()
    {
        _bulletDamage.text = "Урон: " + GameSettings.CurrentSettings.GetBulletDamage();
    }

    public void SetLaserWorkTimeText()
    {
        _laserWorkTime.text = "Время действия: " + GameSettings.CurrentSettings.GetLaserWorkTime() + " c.";
    }

    public void SetLaserLoadTimeText()
    {
        int time = GameSettings.CurrentSettings.GetLaserLoadTime();
        int minutes = time/60;
        int seconds = time%60;
        string text = string.Format("Время зарядки: {0:0} мин.", minutes);
        if(seconds > 0) { text += string.Format(" {0:00} с.", seconds); }
        _laserReloadTime.text = text;
    }

    public void SetLaserDamageText()
    {
        _laserDamage.text = "Урон: " + GameSettings.CurrentSettings.GetLaserDamage()/0.02f + "/с.";
    }

    public void SetMissilesCountText()
    {
        _missilesCount.text = "Количество: " + GameSettings.CurrentSettings.GetMissilesCount();
    }

    public void SetMissileDamageText()
    {
        _missileDamage.text = "Урон: " + GameSettings.CurrentSettings.GetMissileDamage();
    }

    public void SetMissileDamageDiametrText()
    {
        _missileDamageDiametr.text = "Диаметр поражения: " + GameSettings.CurrentSettings.GetMissileDamageDiametr();
    }

    public void SetBonusMagnetrText()
    {
        _bonusMagnet.text = "Время действия магнита: " + GameSettings.CurrentSettings.GetBonusMagnetWorkTime() + " с.";
    }

    public void SetBonusShieldText()
    {
        _bonusShield.text = "Время действия щита: " + GameSettings.CurrentSettings.GetBonusShieldWorkTime() + " с.";
    }

    public void SetBonusStarText()
    {
        _bonusStar.text = "Время действия удвоенного опыта: " + GameSettings.CurrentSettings.GetBonusStarWorkTime() + " с.";
    }

    public void SetBonusPillText()
    {
        _bonusPill.text = "Количество жизней в таблетке: " + GameSettings.CurrentSettings.GetPillHealthCount();
    }


    public void SetAllTextes()
    { 
        SetShipSpeedText();
        SetShipHealthText();
        SetGunsCountText();
        SetShootDelayText();
        SetBulletSpeedText();
        SetBulletDamageText();
        SetLaserWorkTimeText();
        SetLaserLoadTimeText();
        SetLaserDamageText();
        SetMissilesCountText();
        SetMissileDamageText();
        SetMissileDamageDiametrText();
        SetBonusMagnetrText();
        SetBonusShieldText();
        SetBonusStarText();
        SetBonusPillText();
    }

}
