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
        //empieza una corrutina con 3 segundos de espera
        StartCoroutine(StartEgg());
    }

    private IEnumerator StartEgg()
    {
        //espera 3 segundos
        yield return new WaitForSeconds(3);
        //instancia un enemigo
        Instantiate(ant, transform.position, Quaternion.identity);
        Instantiate(ant, transform.position, Quaternion.identity);
        Instantiate(ant, transform.position, Quaternion.identity);
        //destruye el huevo
        Destroy(gameObject);
    }
}
