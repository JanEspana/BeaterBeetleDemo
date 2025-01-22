using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private GameObject settingCanvas;
    private void Start()
    {
        settingCanvas = GameObject.Find("SettingsCanvas");
        settingCanvas.SetActive(false);
    }
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    public void quitGame()
    {
        Application.Quit();
    }


}
