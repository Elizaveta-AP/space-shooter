using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusShield : Bonus
{
    private int _time;
    private GameObject _shieldTimer;

    public override void Start()
    {
        base.Start();

        _shieldTimer = GameObject.Find("SliderShield");

        _time = 10;
    }
 
    public override void GetBonus(GameObject player)
    {
        _shieldTimer.GetComponent<ShieldTimer>().StartTimerCoroutine(_time);
        
        base.GetBonus(player);
    }
}
