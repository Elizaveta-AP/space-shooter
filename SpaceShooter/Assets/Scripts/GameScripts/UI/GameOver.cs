using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text _coins, _score;
    [SerializeField] private GameObject _newRecordText;

    void Start()
    {
        int score = Score.CurrentScore.GetScore();
        int coins = CoinsCount.Count.GetCoins();

        if (GameSettings.CurrentSettings.SetRecord(score))
        {
            _newRecordText.SetActive(true);
        }

        GameSettings.CurrentSettings.AddCoins(coins);
        GameSettings.CurrentSettings.SaveGame();

        _score.text = $"{score}";
        _coins.text = $"{coins}";
    }

    public void ButtonContinue()
    {
        SceneManager.LoadScene(0);
    }
}
