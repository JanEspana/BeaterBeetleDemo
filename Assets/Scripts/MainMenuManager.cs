using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenuManager : MonoBehaviour
{
    private GameObject settingCanvas;
    private UnityEngine.UI.Slider volumeSlider;
    private GameObject username;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("username"))
        {
            PlayerPrefs.SetString("username", "Anonymous");
            PlayerPrefs.Save();
        }
        volumeSlider = GameObject.FindAnyObjectByType<UnityEngine.UI.Slider>();
        settingCanvas = GameObject.Find("SettingsCanvas");
        settingCanvas.SetActive(false);
        username = GameObject.Find("username");
        username.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("username");
    }
    public void toggleSettings()
    {
        if (settingCanvas.active == true)
        {
            settingCanvas.SetActive(false);
        }
        else
        {
            settingCanvas.SetActive(true);
        }
    }
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    public void quitGame()
    {
        Application.Quit();
    }

    public void saveVolume()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.Save();
    }
    
    public void saveUsername()
    {
        PlayerPrefs.SetString("username", username.GetComponent<TMP_InputField>().text);
        PlayerPrefs.Save();
    }
}
