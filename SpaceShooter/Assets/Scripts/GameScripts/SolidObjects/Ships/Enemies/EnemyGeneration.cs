using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemy = new GameObject[1];
    private float _middleFrequency;
    private System.Random _random = new System.Random();
    private float _frequency;
    void Start()
    {
        StartCoroutine(Generation());
    }
    IEnumerator Generation()
    {
        while (true)
        {
            _middleFrequency = GameDifficulty.CurrentDifficulty._enemiesMiddleFrequencyGeneration;
            _frequency = _random.Next(Mathf.CeilToInt(_middleFrequency*50), Mathf.CeilToInt(_middleFrequency*150))/100.0f;

            yield return new WaitForSeconds(_frequency);

            GameObject enemy = Enemy[_random.Next(0, Enemy.Length)];
            Vector3 position = new Vector3(9.5f, _random.Next(-330, 330)/100.0f, 0);
            Instantiate(enemy, position, Quaternion.Euler(0, 0, 90), transform);
        }
    }


}
