using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SavedPlayers : MonoBehaviour
{
    static public int CurrentSave;
    private int _selectedSlot;

    private GameObject _inputField;

    [SerializeField] private GameObject[] Slots;
    private string[] Names = new string[4];

    [SerializeField] private TMP_Text _helloText;
    
    void Start()
    {
        // Slots[0] = transform.Find("Slot0").gameObject;
        // Slots[1] = transform.Find("Slot1").gameObject;
        // Slots[2] = transform.Find("Slot2").gameObject;
        // Slots[3] = transform.Find("Slot3").gameObject;

        _inputField = transform.Find("InputField").gameObject;

        if (PlayerPrefs.HasKey("CurrentSave")) 
        {
            CurrentSave = PlayerPrefs.GetInt("CurrentSave");
            Slots[CurrentSave].transform.Find("Toggle").gameObject.GetComponent<Toggle>().isOn = true;
            _helloText.text = "Добро пожаловть в игру, " + PlayerPrefs.GetString("Slot" + CurrentSave);
        }

        for (int i = 0; i < 4; i++)
        {
            string slotName = "Slot" + i;
            if (PlayerPrefs.HasKey(slotName))
            {
                Names[i] = PlayerPrefs.GetString(slotName);
                Slots[i].transform.Find("Name").GetChild(0).gameObject.GetComponent<TMP_Text>().text = Names[i];
            }
        }

    }

    public void SelectSlot(int slotNumber)
    {
        _selectedSlot = slotNumber;
        Slots[slotNumber].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        Debug.Log("selected slot is " + slotNumber);
    }

    
    public void DeselectSlot(int slotNumber)
    {
        _selectedSlot = slotNumber;
        Slots[slotNumber].GetComponent<Image>().color = new Color(1, 1, 1, 0);
        Debug.Log("slot " + slotNumber + " is deselected");
    }


    public void ChooseSlot(int slotNumber)
    {
        CurrentSave = slotNumber;
        Debug.Log("current save is " + slotNumber);
        if (!PlayerPrefs.HasKey("Slot" + slotNumber)) ButtonName();
        PlayerPrefs.SetInt("CurrentSave", CurrentSave);
        _helloText.text = "Добро пожаловть в игру, " + PlayerPrefs.GetString("Slot" + CurrentSave);
    }

    public void ButtonName()
    {
        _inputField.SetActive(true);
        _inputField.GetComponent<TMP_InputField>().text = Slots[_selectedSlot].transform.Find("Name").GetChild(0).gameObject.GetComponent<TMP_Text>().text;
        _inputField.GetComponent<TMP_InputField>().ActivateInputField();
    }

    public void InputName(string name)
    {
        Debug.Log("selected slot is " + _selectedSlot);

        Slots[_selectedSlot].transform.Find("Name").GetChild(0).gameObject.GetComponent<TMP_Text>().text = name;
        PlayerPrefs.SetString("Slot" + _selectedSlot, name);
        Debug.Log("slot " + _selectedSlot + " is " + name);
        _inputField.SetActive(false);

        Slots[_selectedSlot].transform.Find("Toggle").gameObject.GetComponent<Toggle>().Select();

        if (_selectedSlot == CurrentSave) _helloText.text = "Добро пожаловть в игру, " + PlayerPrefs.GetString("Slot" + CurrentSave);
    }
    
}
