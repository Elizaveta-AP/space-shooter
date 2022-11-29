using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusStar :  Bonus
{
    private int _time;
    private GameObject _starTimer;

    public override void Start()
    {
        base.Start();

        _starTimer = GameObject.Find("SliderStar");

        _time = GameSettings.CurrentSettings.GetBonusStarWorkTime();
    }
 
    public override void GetBonus(GameObject player)
    {
        _starTimer.GetComponent<StarTimer>().StartTimerCoroutine(_time);
        
        base.GetBonus(player);
    }
}
