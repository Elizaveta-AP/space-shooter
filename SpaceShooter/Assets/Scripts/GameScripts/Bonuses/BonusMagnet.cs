using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMagnet : Bonus
{
    private int _time;
    private GameObject _magnetTimer;
    
    public override void Start()
    {
        base.Start();

        _magnetTimer = GameObject.Find("SliderMagnet");

        _time = 10;
    }

    
    public override void GetBonus(GameObject player)
    {
        _magnetTimer.GetComponent<MagnetTimer>().StartTimerCoroutine(_time);
        
        base.GetBonus(player);
    }
}
