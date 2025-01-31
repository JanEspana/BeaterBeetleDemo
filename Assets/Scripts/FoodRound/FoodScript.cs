using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : Character
{
    public override void CheckIfAlive(bool hasKnockback)
    {
        if (HP <= 0)
        {
            //busca todos los objetos con tag enemy y cambia su target al objeto con tag player
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<EnemyController>().target = GameObject.FindGameObjectWithTag("Player");
                enemy.GetComponent<EnemyController>().foodIsAlive = false;
            }
            Die();
        }
        else
        {
            TakeDamage(1);
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
