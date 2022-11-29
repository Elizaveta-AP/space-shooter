using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPill : Bonus
{
    private int _healthValue;

    public override void Start()
    {
        base.Start();
        _healthValue = GameSettings.CurrentSettings.GetPillHealthCount();;
    }

    public override void GetBonus(GameObject player)
    {
        player.GetComponent<Player>().IncreaseHealth(_healthValue);
        base.GetBonus(player);
    }
}
