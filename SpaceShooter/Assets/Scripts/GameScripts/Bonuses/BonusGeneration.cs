using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGeneration : MonoBehaviour
{
    public static BonusGeneration Bonuses;

    [SerializeField] private GameObject _shield, _pill, _star;

    private System.Random _random = new System.Random();

    private void Start() {
        Bonuses = this;
    }

    public void Generation(Vector3 position)
    {
        int newBonus = _random.Next(20);
        switch (newBonus)
        {
            case 0: 
                Instantiate(_shield, position, Quaternion.Euler(0,0,0));
                break;
            case 1: 
                Instantiate(_pill, position, Quaternion.Euler(0,0,0));
                break;
            case 2: 
                Instantiate(_star, position, Quaternion.Euler(0,0,0));
                break;
            default: break;
        }
    }
}
