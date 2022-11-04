using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCount : MonoBehaviour
{
    public static CoinsCount Count;
    private TMP_Text _coinText;
    private int _coinsCount;
    
    void Start()
    {
        Count = this;
        _coinText = (GameObject.Find("CoinsText").GetComponent<TMP_Text>());
        _coinsCount = 0;
        
    }

    public void TakeCoin()
    {
        _coinsCount += 1;
        _coinText.text = $"{_coinsCount}";
    }

    public int GetCoins()
    {
        return _coinsCount;
    }
}
