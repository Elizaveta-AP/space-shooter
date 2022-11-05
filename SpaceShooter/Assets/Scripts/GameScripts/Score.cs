using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score CurrentScore;
    private int _score;
    private TMP_Text _scoreText;
    private int _nextScoreByDifficultyUp = 100;
    private int _scoreMultiplier;
    void Start()
    {
        CurrentScore = this;
        _scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        _score = 0;
        _scoreMultiplier = 1;
    }

    public int GetScore()
    {
        return _score;
    }
    
    public void SetScore(int score)
    {
        _score += score*_scoreMultiplier;
        _scoreText.text = $"Счет: {_score}";

        if (_score >= _nextScoreByDifficultyUp)
        {
            GameDifficulty.CurrentDifficulty.DifficultyUp();
            _nextScoreByDifficultyUp += 100;
        }
    }

    public IEnumerator SetScoreMultiplier(int multiplier, int time)
    {
        _scoreMultiplier = multiplier;

        yield return new WaitForSeconds(time);

        _scoreMultiplier = 1;
    }
}
