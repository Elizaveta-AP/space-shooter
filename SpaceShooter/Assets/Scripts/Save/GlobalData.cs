using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GlobalData : MonoBehaviour
{
    
    public string CurrentSave;
    public string[] Players;
    public int[] Records;

    public GlobalData(GlobalSettings globalSettings){
        CurrentSave = globalSettings.CurrentSave;
        Players = globalSettings.Players;
        Records = globalSettings.Records;
    }

}
