using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    public static GameDifficulty CurrentDifficulty;

    public int _meteorsHealthMultplier, _enemiesMaxHealth, _enemyBulletDamage;
    public float _meteorsMiddleFrequencyGeneration, _meteorsMiddleSpeed, _enemiesMiddleFrequencyGeneration, _enemiesSpeed, _enemiesShootDelay, _enemyBulletSpeed;
    
    private float _killsCounter;


    void Awake()
    {
        CurrentDifficulty = this;

        _killsCounter = 0;

        _meteorsMiddleFrequencyGeneration = 15; // +
        _meteorsMiddleSpeed = 1;                // +
        _meteorsHealthMultplier = 5;            // +
        _enemiesMiddleFrequencyGeneration = 10; // +
        _enemiesMaxHealth = 50;                 // +
        _enemyBulletDamage = 5;                 // +
        _enemyBulletSpeed = 2.0f;               // +
        _enemiesSpeed = 0.2f;                   // +
        _enemiesShootDelay = 3;                 // +
    }

    public void KillsCountUp(float value)
    {
        _killsCounter += value;
        if (_killsCounter >= 5)
        {
            DifficultyUp();
            _killsCounter -= 5;
        }
    }

    private void DifficultyUp()
    {
        _meteorsMiddleFrequencyGeneration *= 0.95f;
        _meteorsMiddleSpeed *= 1.05f;
        _meteorsHealthMultplier += 1;
        _enemiesMiddleFrequencyGeneration *= 0.95f;
        _enemiesMaxHealth += 20;
        _enemyBulletDamage += 2;
        _enemyBulletSpeed += 0.2f;
        _enemiesSpeed += 0.1f;
        _enemiesShootDelay *= 0.95f; 
    }
    
}
