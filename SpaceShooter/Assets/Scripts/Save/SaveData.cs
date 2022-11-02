using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    
    public string Slot;
    public string Name;
    public int Coins;
    public int Record;

    public SaveData(GameSettings gameSettings){
        Slot = gameSettings.Slot;
        Name = gameSettings.Name;
        Coins = gameSettings.Coins;
        Record = gameSettings.Record;
    }

}
