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
    void Awake()
    {
        playerHPBar.GetComponent<Slider>().value = playerHPBar.GetComponent<Slider>().maxValue;
        GenerateEnemy();
    }
    public void GenerateEnemy()
    {
        enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)]);
        enemy.GetComponent<Character>().slider = enemyHPBar;
        enemyHPBar.GetComponent<Slider>().value = enemyHPBar.GetComponent<Slider>().maxValue;
    }
}
