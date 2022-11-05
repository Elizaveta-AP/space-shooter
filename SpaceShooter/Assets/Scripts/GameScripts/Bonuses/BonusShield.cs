using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusShield : Bonus
{
    [SerializeField] GameObject _shield;
    public override void GetBonus(GameObject player)
    {
        Instantiate(_shield, player.transform);
        base.GetBonus(player);
    }


}
