using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRoundManager : MonoBehaviour
{
    //timer
    public float timeBetweenEggs = 3f;
    public float totalTimer = 30f;
    public GameObject eggPrefab;
    public void Start()
    {
        StartFoodRound();
    }
    public void StartFoodRound()
    {
        StartCoroutine(FoodRound());
    }
    IEnumerator FoodRound()
    {
        float timer = 0;
        while (timer < totalTimer)
        {
            timer += Time.deltaTime;
            yield return new WaitForSeconds(timeBetweenEggs);
            //instatiate egg in random position
            Vector3 randomPos = new Vector3(Random.Range(-20, 20), 2, Random.Range(-20, 20));
            Instantiate(eggPrefab, randomPos, Quaternion.identity);
        }
        Debug.Log("Food Round Over");
    }
}
