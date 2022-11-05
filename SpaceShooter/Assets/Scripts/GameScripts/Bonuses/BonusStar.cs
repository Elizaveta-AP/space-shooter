using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusStar :  Bonus
{
    private int _scoreMultiplier, _time;

    public override void Start()
    {
        base.Start();
        _scoreMultiplier = 2;
        _time = 10;
    }

    public override void GetBonus(GameObject player)
    {
        StartCoroutine(Score.CurrentScore.SetScoreMultiplier(_scoreMultiplier, _time));
        base.GetBonus(player);
    }
}
