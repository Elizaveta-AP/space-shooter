using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    private static int _score;
    private static TMP_Text _scoreText;
    void Start()
    {
        _scoreText = (GameObject.Find("ScoreText").GetComponent<TMP_Text>());
        _score = 0;
    }

    
    public static void SetScore(int score){
        _score += score;
        _scoreText.text = $"Счет: {_score}";
    }
}
