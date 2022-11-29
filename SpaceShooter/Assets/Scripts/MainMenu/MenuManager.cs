using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Menu;
    public int CurrentSave;

    private TMP_Text _helloText, _recordText, _coinsText;
    private GameObject _shopMenu, _playersMenu;

    private void Awake() 
    {
        Menu = this;

        _helloText = GameObject.Find("HelloText").GetComponent<TMP_Text>();
        _recordText = GameObject.Find("RecordText").GetComponent<TMP_Text>();
        _coinsText = GameObject.Find("CoinsText").GetComponent<TMP_Text>();

        _shopMenu = transform.Find("Shop").gameObject;
        _playersMenu = transform.Find("Players").gameObject;

    }

    private void Start() 
    {
        if (PlayerPrefs.HasKey("CurrentSave")) 
        {
            CurrentSave = PlayerPrefs.GetInt("CurrentSave");
            SetAllTextes();
        }
    }
    
    public void ButtonStart()
    {
        SceneManager.LoadScene(1);
    }
    
    public void ButtonShop(bool isOn)
    {
        _shopMenu.SetActive(isOn);
    }

    public void ButtonPlayers(bool isOn)
    {
        _playersMenu.SetActive(isOn);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }



    public void SetHelloText()
    {
        _helloText.text = "Добро пожаловть в игру, " + GameSettings.CurrentSettings.Name;
    }

    public void SetRecordText()
    {
        _recordText.text = GameSettings.CurrentSettings.GetRecord().ToString();
    }

    public void SetCoinsText()
    {
        _coinsText.text = GameSettings.CurrentSettings.GetCoins().ToString();
    }

    public void SetAllTextes()
    {
        SetHelloText();
        SetRecordText();
        SetCoinsText();
    }
}
