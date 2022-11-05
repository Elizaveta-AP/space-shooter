using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    
    public void ButtonShipSpeed()
    {
        if (GameSettings.CurrentSettings.SpendCoins(50))
        { 
            GameSettings.CurrentSettings.ImproveSpeed(1);
            PrintPlayerCharacteristics.PrintCharacteristics.SetShipSpeedText(); 
        }
    }

    public void ButtonShipHealth()
    {
        if (GameSettings.CurrentSettings.SpendCoins(50))
        { 
            GameSettings.CurrentSettings.ImproveMaxHealth(100);
            PrintPlayerCharacteristics.PrintCharacteristics.SetShipHealthText(); 
        }
    }

    public void ButtonShootDelay()
    {
        if (GameSettings.CurrentSettings.SpendCoins(50))
        { 
            GameSettings.CurrentSettings.ImproveShootDelay(0.1f);
            PrintPlayerCharacteristics.PrintCharacteristics.SetShootDelayText(); 
        }
    }

    public void ButtonBulletSpeed()
    {
        if (GameSettings.CurrentSettings.SpendCoins(50))
        { 
            GameSettings.CurrentSettings.ImproveBulletSpeed(2);
            PrintPlayerCharacteristics.PrintCharacteristics.SetBulletSpeedText(); 
        }
    }

    public void ButtonBulletDamage()
    {
        if (GameSettings.CurrentSettings.SpendCoins(50))
        { 
            GameSettings.CurrentSettings.ImproveBulletDamage(5);
            PrintPlayerCharacteristics.PrintCharacteristics.SetBulletDamageText(); 
        }
    }

}
