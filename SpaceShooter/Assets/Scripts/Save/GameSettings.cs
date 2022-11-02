using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public string Slot;
    public string Name;
    public int Coins;
    public int Record;

    public void LoadGame(string slot)
	{
		SaveData data = SaveLoadManager.LoadGame(slot); //Получение данных

		if(!data.Equals(null)) //Если данные есть
		{
            Slot = data.Slot;
            Name = data.Name;
            Coins = data.Coins;
            Record = data.Record;
		}
        else{
            Slot = slot;
            Name = "Новый игрок";
            Coins = 0;
            Record = 0;
        }
	}
}
