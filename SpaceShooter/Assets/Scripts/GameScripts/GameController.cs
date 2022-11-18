using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController ThisGameController;
    [SerializeField] private GameObject _upPanel, _downPanel, _gameOverPanel;
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
                Time.timeScale = 1;
                _isPause = false;
            }
            else
            {
                Time.timeScale = 0;
                _isPause = true;
            }
        }
    }

    public void GameOver()
    {
        _upPanel.SetActive(false);
        _downPanel.SetActive(false);
        _gameOverPanel.SetActive(true);
    }

}
