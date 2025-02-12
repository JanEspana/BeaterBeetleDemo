using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodScript : Character
{
    public Slider healthBarSlider;
    private void Awake()
    {
        healthBarSlider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        healthBarSlider.maxValue = HP;
        healthBarSlider.value = HP;
    }
    public override void CheckIfAlive(bool hasKnockback)
    {
        healthBarSlider.value = HP;
        if (HP <= 0)
        {
            //busca todos los objetos con tag enemy y cambia su target al objeto con tag player
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                if (enemy.GetComponent<EnemyController>() != null)
                {
                    enemy.GetComponent<EnemyController>().target = GameObject.FindGameObjectWithTag("Player");
                    enemy.GetComponent<EnemyController>().foodIsAlive = false;
                }

            }
            Destroy(gameObject);
        }
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
