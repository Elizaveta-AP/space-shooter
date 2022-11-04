using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    
    public string Slot;
    public string Name;
    public int Coins;
    public int Record;
    public float Speed;
    public float ShootDelay;
    public int MaxHealth;
    public float BulletSpeed;
    public int BulletDamage;

    public SaveData(){
        Slot = GameSettings.CurrentSettings.GetSlot();
        Name = GameSettings.CurrentSettings.Name;
        Coins = GameSettings.CurrentSettings.GetCoins();
        Record = GameSettings.CurrentSettings.GetRecord();
        Speed = GameSettings.CurrentSettings.GetSpeed();
        ShootDelay = GameSettings.CurrentSettings.GetShootDelay();
        MaxHealth = GameSettings.CurrentSettings.GetMaxHealth();
        BulletSpeed = GameSettings.CurrentSettings.GetBulletSpeed();
        BulletDamage = GameSettings.CurrentSettings.GetBulletDamage();
    }

}
