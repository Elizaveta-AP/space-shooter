using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MeteorsGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] Meteors = new GameObject[8];
    private float _middleFrequency;
    private System.Random _random = new System.Random();
    private float _frequency;
    void Start()
    {
        StartCoroutine(Generation());
    }
    IEnumerator Generation(){
        while (true)
        {
            _middleFrequency = GameDifficulty.CurrentDifficulty._meteorsMiddleFrequencyGeneration;
            _frequency = _random.Next(Mathf.CeilToInt(_middleFrequency*50), Mathf.CeilToInt(_middleFrequency*150))/100.0f;

            yield return new WaitForSeconds(_frequency);

            GameObject meteor = Meteors[_random.Next(0, Meteors.Length)];
            Vector3 position = new Vector3(10, _random.Next(-500, 400)/100.0f, 0);
            Instantiate(meteor, position, Quaternion.Euler(0, 0, _random.Next(0, 360)));
        }
    }


}
