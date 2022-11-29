[System.Serializable]

public class SaveData
{
    public int Slot;
    public string Name;
    public int Coins;
    public int Record;
    public int Speed;
    public float ShootDelay;
    public int MaxHealth;
    public int BulletSpeed;
    public int BulletDamage;
    public bool HasAdditionalGuns;
    public int LaserWorkTime;
    public int LaserReloadTime;
    public int LaserDamage;
    public int MissilesCount;
    public int MissileDamage;
    public float MissileDamageDiametr;
    public int BonusStarWorkTime, BonusShieldWorkTime, BonusMagnetWorkTime, PillHealthCount;
    
 
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
        HasAdditionalGuns = GameSettings.CurrentSettings.GetHasAdditionalGuns();
        LaserWorkTime = GameSettings.CurrentSettings.GetLaserWorkTime();
        LaserReloadTime = GameSettings.CurrentSettings.GetLaserLoadTime();
        LaserDamage = GameSettings.CurrentSettings.GetLaserDamage();
        MissilesCount = GameSettings.CurrentSettings.GetMissilesCount();
        MissileDamage = GameSettings.CurrentSettings.GetMissileDamage();
        MissileDamageDiametr = GameSettings.CurrentSettings.GetMissileDamageDiametr();
        BonusStarWorkTime = GameSettings.CurrentSettings.GetBonusStarWorkTime();
        BonusShieldWorkTime = GameSettings.CurrentSettings.GetBonusShieldWorkTime();
        BonusMagnetWorkTime = GameSettings.CurrentSettings.GetBonusMagnetWorkTime();
        PillHealthCount = GameSettings.CurrentSettings.GetPillHealthCount();
    }
}