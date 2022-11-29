using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Leaderboard : MonoBehaviour
{
    public static Leaderboard CurrentLeaderboard;

    [NonSerialized] public int[] Values;
    [NonSerialized] public string[] Names;

    private int _minScoreValue;
    

    void Start()
    {
        CurrentLeaderboard = this;

        LoadLeaderboard();

        _minScoreValue = Values[^1];
    }


    public void LoadLeaderboard()
	{
		LeaderboardData data = SaveLoadRecords.LoadLeaderboard();

		if(data!=null)
		{
            Values = data.Values;
            Names = data.Names;
		}
        else
        {
            Values = new int[10];
            Names = new string[10];

            SaveLeaderboard();
        }
	}
 

    public void SaveLeaderboard()
    {
        SaveLoadRecords.SaveLeaderboard();
    }


    public void CompareValue(int value)
    {
        if (value > _minScoreValue) { AddNewLeader(value); }
    }
    

    private void AddNewLeader(int value)
    {
        for (int i = Values.Length - 2; i >= 0; i--)
        {
            
            if (value > Values[i] && i != 0)
            {
                Values[i + 1] = Values[i];
                Names[i + 1] = Names[i];
            }
            else if (i == 0)
            {
                Values[i + 1] = Values[i];
                Names[i + 1] = Names[i];

                Values[i] = value;
                Names[i] = GameSettings.CurrentSettings.Name;

                SaveLeaderboard();
            }
            else
            {
                Values[i + 1] = value;
                Names[i + 1] = GameSettings.CurrentSettings.Name;
                SaveLeaderboard();
                break;
            }
        }
    }

}
