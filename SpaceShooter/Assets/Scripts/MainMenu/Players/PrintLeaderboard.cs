using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrintLeaderboard : MonoBehaviour
{
    [SerializeField] private TMP_Text[] Names, Scores;


    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            string name = Leaderboard.CurrentLeaderboard.Names[i];
            int score = Leaderboard.CurrentLeaderboard.Values[i];

            if (score == 0) { break; }

            Names[i].text = name;
            Scores[i].text = score.ToString();
        }
    }


}
