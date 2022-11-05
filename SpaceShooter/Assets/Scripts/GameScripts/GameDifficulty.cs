using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    public static GameDifficulty CurrentDifficulty;

    public int _meteorsHealthMultplier, _enemiesMaxHealth, _enemyBulletDamage;
    public float _meteorsMiddleFrequencyGeneration, _meteorsMiddleSpeed, _enemiesMiddleFrequencyGeneration, _enemiesSpeed, _enemiesShootDelay, _enemyBulletSpeed;
    
    void Awake()
    {
        CurrentDifficulty = this;

        _meteorsMiddleFrequencyGeneration = 15; // +
        _meteorsMiddleSpeed = 1;                // +
        _meteorsHealthMultplier = 5;            // +
        _enemiesMiddleFrequencyGeneration = 10; // +
        _enemiesMaxHealth = 50;                 // +
        _enemyBulletDamage = 5;                 // +
        _enemyBulletSpeed = 2.0f;               // +
        _enemiesSpeed = 0.2f;                   // +
        _enemiesShootDelay = 3;                 // +

        
        // Debug.Log($"meteorsMiddleFrequencyGeneration = {_meteorsMiddleFrequencyGeneration}");
        // Debug.Log($"meteorsMiddleSpeed = {_meteorsMiddleSpeed}");
        // Debug.Log($"meteorsHealthMultplier = {_meteorsHealthMultplier}");
        // Debug.Log($"enemiesMiddleFrequencyGeneration = {_enemiesMiddleFrequencyGeneration}");
        // Debug.Log($"enemiesMaxHealth = {_enemiesMaxHealth}");
        // Debug.Log($"enemyBulletDamage = {_enemyBulletDamage}");
        // Debug.Log($"enemyBulletSpeed = {_enemyBulletSpeed}");
        // Debug.Log($"enemiesSpeed = {_enemiesSpeed}");
        // Debug.Log($"enemiesShootDelay = {_enemiesShootDelay}");
    }

    public void DifficultyUp()
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
        // Debug.Log($"meteorsMiddleFrequencyGeneration = {_meteorsMiddleFrequencyGeneration}");
        // Debug.Log($"meteorsMiddleSpeed = {_meteorsMiddleSpeed}");
        // Debug.Log($"meteorsHealthMultplier = {_meteorsHealthMultplier}");
        // Debug.Log($"enemiesMiddleFrequencyGeneration = {_enemiesMiddleFrequencyGeneration}");
        // Debug.Log($"enemiesMaxHealth = {_enemiesMaxHealth}");
        // Debug.Log($"enemyBulletDamage = {_enemyBulletDamage}");
        // Debug.Log($"enemyBulletSpeed = {_enemyBulletSpeed}");
        // Debug.Log($"enemiesSpeed = {_enemiesSpeed}");
        // Debug.Log($"enemiesShootDelay = {_enemiesShootDelay}");
    }
    
}
