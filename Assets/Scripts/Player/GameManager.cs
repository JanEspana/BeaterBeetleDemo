using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public MenuManager menuManager;
    public GameObject playerHPBar, enemyHPBar;
    public List<GameObject> enemyPrefabs;
    public GameObject enemy, player;
    public Canvas statsMenu, hpBars;
    void Awake()
    {
        menuManager = GameObject.Find("GameManager").GetComponent<MenuManager>();
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHPBar.GetComponent<Slider>().value = playerHPBar.GetComponent<Slider>().maxValue;
        StartRound();
    }
    public void StartRound()
    {
        Cursor.lockState = CursorLockMode.Locked;
        statsMenu.GetComponent<Canvas>().enabled = false;
        enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)]);
        enemy.GetComponent<Character>().slider = enemyHPBar;
        enemyHPBar.GetComponent<Slider>().value = enemyHPBar.GetComponent<Slider>().maxValue;
    }
    private void Update()
    {
        if (enemy == null)
        {
            Cursor.lockState = CursorLockMode.None;
            statsMenu.enabled = true;
        }
    }
}
