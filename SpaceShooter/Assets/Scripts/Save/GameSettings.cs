using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings CurrentSettings;

    private int _slot;
    public string Name;
    private int _coins;
    private int _record;
    private int _speed;
    private float _shootDelay;
    private int _maxHealth;
    private int _bulletSpeed;
    private int _bulletDamage;
    private bool _hasAdditionalGuns;
    private int _laserWorkTime;
    private int _laserLoadTime;
    private int _laserDamage;
    private int _missilesCount;
    private int _missileDamage;
    private float _missileDamageDiametr;
    private int _bonusStarWorkTime, _bonusShieldWorkTime, _bonusMagnetWorkTime, _pillHealthCount;

    
    private void Awake() 
    {
        CurrentSettings = this;
        if (PlayerPrefs.HasKey("CurrentSave")) 
        {
            LoadGame(PlayerPrefs.GetInt("CurrentSave"));
        }
    }

    public void LoadGame(int slot)
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
            _hasAdditionalGuns = data.HasAdditionalGuns;
            _laserWorkTime = data.LaserWorkTime;
            _laserLoadTime = data.LaserReloadTime;
            _laserDamage = data.LaserDamage;
            _missilesCount = data.MissilesCount;
            _missileDamage = data.MissileDamage;
            _missileDamageDiametr = data.MissileDamageDiametr;
            _bonusStarWorkTime = data.BonusStarWorkTime;
            _bonusShieldWorkTime = data.BonusShieldWorkTime;
            _bonusMagnetWorkTime = data.BonusMagnetWorkTime;
            _pillHealthCount = data.PillHealthCount;
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
            _bulletSpeed = 5;
            _bulletDamage = 5;
            _hasAdditionalGuns = false;
            _laserWorkTime = 10;
            _laserLoadTime = 180;
            _laserDamage = 1;
            _missilesCount = 10;
            _missileDamage = 50;
            _missileDamageDiametr = 2;
            _bonusStarWorkTime = 10;
            _bonusShieldWorkTime = 10;
            _bonusMagnetWorkTime = 10;
            _pillHealthCount = 50;

            SaveGame();
        }
	}
 

    public void SaveGame()
    {
        SaveLoadManager.SaveGame();
    }


    // Slot
    public int GetSlot() { return _slot; }


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
    public int GetSpeed() { return _speed; }

    public void SetSpeed(int value) 
    { 
        _speed = value; 
        SaveGame();
    }
    

    // Shoot Delay
    public float GetShootDelay() { return _shootDelay; }

    public void SetShootDelay(float value) 
    { 
        _shootDelay = value;
        SaveGame();
    }
    

    // Max Health
    public int GetMaxHealth() { return _maxHealth; }

    public void SetMaxHealth(int value) 
    { 
        _maxHealth = value; 
        SaveGame();
    }


    // Bullet Speed
    public int GetBulletSpeed() { return _bulletSpeed; }

    public void SetBulletSpeed(int value) 
    { 
        _bulletSpeed = value;
        SaveGame();
    }


    // Bullet Damage
    public int GetBulletDamage() { return _bulletDamage; }

    public void SetBulletDamage(int value) 
    { 
        _bulletDamage = value; 
        SaveGame();
    }


    // Guns
    public bool GetHasAdditionalGuns() { return _hasAdditionalGuns; }

    public void BuyAdditionalGuns() 
    { 
        _hasAdditionalGuns = true; 
        SaveGame();
    }


    // Laser Work Time
    public int GetLaserWorkTime() { return _laserWorkTime; }

    public void SetLaserWorkTime(int value) 
    { 
        _laserWorkTime = value; 
        SaveGame();
    }


    // Laser Reload Time
    public int GetLaserLoadTime() { return _laserLoadTime; }

    public void SetLaserLoadTime(int value) 
    { 
        _laserLoadTime = value; 
        SaveGame();
    }


    // Laser Damage
    public int GetLaserDamage() { return _laserDamage; }

    public void SetLaserDamage(int value) 
    { 
        _laserDamage = value; 
        SaveGame();
    }


    // Missiles Count
    public int GetMissilesCount() { return _missilesCount; }

    public void BuyMissile() 
    { 
        _missilesCount += 1; 
        SaveGame();
    }

    public bool UseMissile() 
    { 
        if (_missilesCount > 0)
        {
            _missilesCount -= 1;
            return true;
        }
        else { return false; }
        
    }

    // Missile Damage
    public int GetMissileDamage() { return _missileDamage; }

    public void SetMissileDamage(int value) 
    { 
        _missileDamage = value; 
        SaveGame();
    }
 

    // Missile Damage Diametr
    public float GetMissileDamageDiametr() { return _missileDamageDiametr; }

    public void SetMissileDamageDiametr(float value) 
    { 
        _missileDamageDiametr = value; 
        SaveGame();
    }   
 

    // Bonus Star Work Time
    public int GetBonusStarWorkTime() { return _bonusStarWorkTime; }

    public void SetBonusStarWorkTime(int value) 
    { 
        _bonusStarWorkTime = value; 
        SaveGame();
    }   
 

    // Bonus Shield Work Time
    public int GetBonusShieldWorkTime() { return _bonusShieldWorkTime; }

    public void SetBonusShieldWorkTime(int value) 
    { 
        _bonusShieldWorkTime = value; 
        SaveGame();
    } 


    // Pill Health Number
    public int GetPillHealthCount() { return _pillHealthCount; }

    public void SetPillHealthCount(int value) 
    { 
        _pillHealthCount = value; 
        SaveGame();
    } 
 

    // Bonus Magnet Work Time
    public int GetBonusMagnetWorkTime() { return _bonusMagnetWorkTime; }

    public void SetBonusMagnetWorkTime(int value) 
    { 
        _bonusMagnetWorkTime = value; 
        SaveGame();
    }
}
