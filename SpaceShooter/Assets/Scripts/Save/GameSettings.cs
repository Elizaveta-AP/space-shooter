using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings CurrentSettings;

    private string _slot;
    public string Name;
    private int _coins;
    private int _record;
    private float _speed;
    private float _shootDelay;
    private int _maxHealth;
    private float _bulletSpeed;
    private int _bulletDamage;

    private void Awake() 
    {
        CurrentSettings = this;
        if (PlayerPrefs.HasKey("CurrentSave")) 
        {
            LoadGame("Slot" + PlayerPrefs.GetInt("CurrentSave"));
        }
    }

    public void LoadGame(string slot)
	{
		SaveData data = SaveLoadManager.LoadGame(slot);

		if(data!=null)
		{
            _slot = data.Slot;
            Name = data.Name;
            _coins = data.Coins;
            _record = data.Record;
            _speed = data.Speed;
            _shootDelay = data.ShootDelay;
            _maxHealth = data.MaxHealth;
            _bulletSpeed = data.BulletSpeed;
            _bulletDamage = data.BulletDamage;
		}
        else
        {
            _slot = slot;
            Name = "Новый игрок";
            _coins = 0;
            _record = 0;
            _speed = 5;
            _shootDelay = 1;
            _maxHealth = 100;
            _bulletSpeed = 5.0f;
            _bulletDamage = 5;

            SaveGame();
        }
        MenuManager.Menu.SetRecordText();
        MenuManager.Menu.SetCoinsText();
	}

    public void SaveGame()
    {
        SaveLoadManager.SaveGame();
    }

    // Slot
    public string GetSlot() { return _slot; }

    // Coins
    public int GetCoins() { return _coins; }

    public bool SpendCoins(int value)
    {
        if (_coins > value) 
        { 
            _coins -= value;
            MenuManager.Menu.SetCoinsText();
            return true; 
        }
        else { return false; }
    }

    public void AddCoins(int value) { _coins += value; }

    // Record
    public int GetRecord() { return _record; }

    public bool SetRecord(int score)
    {
        if (score > _record) 
        { 
            _record = score;
            return true; 
        }
        else { return false; }
    }

    // Speed
    public float GetSpeed() { return _speed; }

    public void SetSpeed(float speed) { _speed = speed; }
    
    // Shoot Delay
    public float GetShootDelay() { return _shootDelay; }

    public void SetShootDelay(float shootDelay) { _shootDelay = shootDelay; }
    
    // Max Health
    public int GetMaxHealth() { return _maxHealth; }

    public void SetMaxHealth(int maxHealth) { _maxHealth = maxHealth; }

    // BulletSpeed
    public float GetBulletSpeed() { return _bulletSpeed; }

    public void SetBulletSpeed(int bulletSpeed) { _bulletSpeed = bulletSpeed; }

    // BulletDamage
    public int GetBulletDamage() { return _bulletDamage; }

    public void SetBulletDamage(int bulletDamage) { _bulletDamage = bulletDamage; }



}
