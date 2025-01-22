using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject playerHPBar, enemyHPBar;
    public List<GameObject> enemyPrefabs;
    public GameObject enemy;
    public Canvas statsMenu, hpBars;
    void Awake()
    {
        instance = this;
        playerHPBar.GetComponent<Slider>().value = playerHPBar.GetComponent<Slider>().maxValue;
        StartRound();
    }
    public void StartRound()
    {
        Cursor.lockState = CursorLockMode.Locked;
        statsMenu.gameObject.SetActive(false);
        enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)]);
        enemy.GetComponent<Character>().slider = enemyHPBar;
        enemyHPBar.GetComponent<Slider>().value = enemyHPBar.GetComponent<Slider>().maxValue;
    }
    private void Update()
    {
        if (enemy == null)
        {
            Cursor.lockState = CursorLockMode.None;
            statsMenu.gameObject.SetActive(true);
        }
    }
}
