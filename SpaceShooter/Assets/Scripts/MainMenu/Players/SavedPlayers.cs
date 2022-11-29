using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SavedPlayers : MonoBehaviour
{

    [SerializeField] private ColorChanger[] ColorChangingElements;
    private GameObject _inputField;

    private GameObject[] Slots = new GameObject[4];
    private string[] Names = new string[4];

    
    void Start()
    {
        Slots[0] = transform.Find("Slot0").gameObject;
        Slots[1] = transform.Find("Slot1").gameObject;
        Slots[2] = transform.Find("Slot2").gameObject;
        Slots[3] = transform.Find("Slot3").gameObject;

        _inputField = transform.Find("InputField").gameObject;

        for (int i = 0; i < 4; i++)
        {
            string slotName = "Slot" + i;
            if (PlayerPrefs.HasKey(slotName))
            {
                Names[i] = PlayerPrefs.GetString(slotName);
                Slots[i].gameObject.GetComponentInChildren<TMP_Text>().text = Names[i];
            }
        }

        if (PlayerPrefs.HasKey("CurrentSave")) 
        {
            Slots[MenuManager.Menu.CurrentSave].transform.GetComponent<Toggle>().isOn = true;
        }
    }


    public void ChooseSlot(int slotNumber)
    {
        if (slotNumber != MenuManager.Menu.CurrentSave)
        {
            MenuManager.Menu.CurrentSave = slotNumber;
            string saveName = "Slot" + slotNumber;

            PlayerPrefs.SetInt("CurrentSave", slotNumber);
            PlayerPrefs.Save();
        
            GameSettings.CurrentSettings.LoadGame(slotNumber);

            if (!PlayerPrefs.HasKey(saveName)) ButtonName();

            MenuManager.Menu.SetAllTextes();

            foreach (ColorChanger element in ColorChangingElements)
            {
                element.ChangeColor();
            }
        }
    }

    public void ButtonName()
    {
        _inputField.SetActive(true);
        _inputField.GetComponent<TMP_InputField>().text = Slots[MenuManager.Menu.CurrentSave].GetComponentInChildren<TMP_Text>().text;
        _inputField.GetComponent<TMP_InputField>().ActivateInputField();
    }

    public void InputName(string name)
    {
        Slots[MenuManager.Menu.CurrentSave].GetComponentInChildren<TMP_Text>().text = name;
        PlayerPrefs.SetString("Slot" + MenuManager.Menu.CurrentSave, name);
        PlayerPrefs.Save();

        GameSettings.CurrentSettings.Name = name;
        GameSettings.CurrentSettings.SaveGame();

        _inputField.SetActive(false);

        MenuManager.Menu.SetHelloText();
    }

}
