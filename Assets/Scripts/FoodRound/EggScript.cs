using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : Character
{
    public GameObject ant;

    public override void CheckIfAlive(bool hasKnockback)
    {
        if (HP <= 0)
        {
            Debug.Log("Egg Destroyed");
            Destroy(gameObject);
        }
    }

    public override void Die()
    {
    }

    private void Awake()
    {
        StartCoroutine(StartEgg());
    }

    private IEnumerator StartEgg()
    {
        yield return new WaitForSeconds(3);
        Instantiate(ant, transform.position, Quaternion.identity);
        Instantiate(ant, transform.position, Quaternion.identity);
        Instantiate(ant, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
