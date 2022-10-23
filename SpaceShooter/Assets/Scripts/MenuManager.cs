using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    public void ButtonStart(){
        Debug.Log("true");
        SceneManager.LoadScene(1);
    }
    
    public void ButtonQuit(){
        Application.Quit();
    }
}
