using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemy = new GameObject[1];
    [SerializeField] private int _middleFrequency;
    private System.Random _random = new System.Random();
    private int _frequency;
    void Start()
    {
        StartCoroutine(Generation());
    }
    IEnumerator Generation(){
        int frequency = _random.Next(_middleFrequency/2, _middleFrequency*3/2);
        while (true)
        {    
            yield return new WaitForSeconds(frequency);
            GameObject enemy = Enemy[_random.Next(0, Enemy.Length)];
            Vector3 position = new Vector3(10, _random.Next(-430, 330)/100.0f, 0);
            Instantiate(enemy, position, Quaternion.Euler(0, 0, 180));
            frequency = _random.Next(_middleFrequency - _middleFrequency/2, _middleFrequency + _middleFrequency/2);
        }
    }


}
