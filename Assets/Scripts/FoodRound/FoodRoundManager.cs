using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodRoundManager : MonoBehaviour
{
    //timer
    public float timeBetweenEggs = 3f;
    public float totalTimer = 10f;
    public float timer;
    public GameObject eggPrefab;
    public GameObject foodPrefab;
    public GameObject roundTimer;
    public void Start()
    {
        StartFoodRound();
    }
    public void StartFoodRound()
    {
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
            Vector3 randomPos = new Vector3(Random.Range(-20, 20), 2, Random.Range(-20, 20));
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
    }
}
