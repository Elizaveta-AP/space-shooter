using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MeteorsGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] Meteors = new GameObject[8];
    [SerializeField] private int _middleFrequency;
    System.Random _random = new System.Random();
    private int frequency;
    void Start()
    {
        StartCoroutine(Generation());
    }
    IEnumerator Generation(){
        int frequency = _random.Next(_middleFrequency/2, _middleFrequency*3/2);
        while (true)
        {    
            yield return new WaitForSeconds(frequency);
            GameObject meteor = Meteors[_random.Next(0, Meteors.Length)];
            Vector3 position = new Vector3(11, _random.Next(-500, 500)/100.0f, 0);
            Instantiate(meteor, position, Quaternion.Euler(0, 0, _random.Next(0, 360)));
            frequency = _random.Next(_middleFrequency - _middleFrequency/2, _middleFrequency + _middleFrequency/2);
        }
    }


}
