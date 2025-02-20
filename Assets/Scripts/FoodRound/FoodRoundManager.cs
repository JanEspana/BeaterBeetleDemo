using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodRoundManager : MonoBehaviour
{
    public static FoodRoundManager instance;
    public float timeBetweenEggs;
    public float totalTimer;
    public float timer;
    public GameObject eggPrefab;
    public GameObject foodPrefab;
    public GameObject roundTimer;
    public GameObject upgradeMenu;
    public GameObject roundMenu;
    public List<GameObject> UpgradeButtons = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }
    public void StartFoodRound()
    {
        roundMenu.GetComponent<Canvas>().enabled = true;
        Instantiate(foodPrefab, new Vector3(5, 20, 0), Quaternion.identity);
        StartCoroutine(EggSpawn());
        StartCoroutine(RoundTimer());
    }
    IEnumerator EggSpawn()
    {
        while (timer < totalTimer)
        {
            yield return new WaitForSeconds(timeBetweenEggs);
            //instatiate egg in random position
            Vector3 randomPos = new Vector3(Random.Range(-20, 20), 1, Random.Range(-20, 20));
            Instantiate(eggPrefab, randomPos, Quaternion.identity);
        }
        Debug.Log("Food Round Over");
    }
    IEnumerator RoundTimer()
    {
        timer = 0;
        while (timer < totalTimer)
        {
            timer += Time.deltaTime;
            roundTimer.GetComponent<TextMeshProUGUI>().text = (totalTimer - timer).ToString("F0");
            yield return null;
        }
        //pausa el juego
        Time.timeScale = 0;
        //busca todos los objetos con tag enemy y los destruye
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        foreach (GameObject button in UpgradeButtons)
        {
            button.GetComponent<UpgradeMenu>().SelectRandomUpgrade();
        }
        Destroy(GameObject.FindGameObjectWithTag("Food"));
        upgradeMenu.GetComponent<Canvas>().enabled = true;
        roundMenu.GetComponent<Canvas>().enabled = false;

    }
}
