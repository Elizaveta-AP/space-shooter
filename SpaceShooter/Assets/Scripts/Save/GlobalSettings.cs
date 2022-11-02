using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    public string CurrentSave;
    public string[] Players;
    public int[] Records;

    public void LoadGame(string slot)
	{
		SaveData data = SaveLoadManager.LoadGame(slot); //Получение данных

		if(!data.Equals(null)) //Если данные есть
		{
		}
        else{
        }
	}
}
