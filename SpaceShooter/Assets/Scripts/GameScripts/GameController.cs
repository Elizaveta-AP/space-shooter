using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController ThisGameController;
    [SerializeField] private GameObject _upPanel, _downPanel, _gameOverPanel, _pausePanel;
    private bool _isPause;
    
    void Start()
    {
        ThisGameController = this;
        
        _isPause = false;
    }

    private void Update() 
    {
        if (Input.GetButtonUp("Cancel"))
        {
            if (_isPause)
            {
                _isPause = false;
                _pausePanel.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                _isPause = true;
                _pausePanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void GameOver()
    {
        _upPanel.SetActive(false);
        _downPanel.SetActive(false);
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

}
