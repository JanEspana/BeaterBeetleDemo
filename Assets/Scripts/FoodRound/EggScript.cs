using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{
    public GameObject ant;
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
