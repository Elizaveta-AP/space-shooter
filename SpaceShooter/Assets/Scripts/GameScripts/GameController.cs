using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController ThisGameController;
    
    void Start()
    {
        ThisGameController = this;
    }

    public void GameOver(){
        GameSettings.CurrentSettings.SetRecord(Score.CurrentScore.GetScore());
        GameSettings.CurrentSettings.AddCoins(CoinsCount.Count.GetCoins());
        GameSettings.CurrentSettings.SaveGame();
    }

}
