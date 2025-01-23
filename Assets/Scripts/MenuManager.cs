using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Slider hpBar, UIhpBar;
    public TextMeshProUGUI calories;
    public void ActiveCanvas()
    {
        Player player = GameManager.instance.player.GetComponent<Player>();
        if (player.HP + 3 > 10)
        {
            player.HP = 10;
        }
        else
        {
            player.HP += 3;
        }
        hpBar.value = GameManager.instance.player.GetComponent<Player>().HP/10;
        UIhpBar.value = GameManager.instance.player.GetComponent<Player>().HP / 10;
        calories.text = GameManager.instance.player.GetComponent<Player>().calories.ToString();
    }
    public void NextBattle()
    {
        GameManager.instance.StartRound();
        hpBar.value = GameManager.instance.player.GetComponent<Player>().HP / 10;
        UIhpBar.value = GameManager.instance.player.GetComponent<Player>().HP / 10;
        GameManager.instance.player.gameObject.transform.position = new Vector3(0, 2, 0);
        GameManager.instance.player.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

    }
    public void UpgradeHP()
    {
        Player player = GameManager.instance.player.GetComponent<Player>();
        if (player.HP != 10 && player.calories >= 100)
        {
            if (player.HP + 1 > 10)
            {
                player.HP = 10;
                UIhpBar.value = 1;
                hpBar.value = 1;
            }
            else
            {
                player.HP += 1;
                UIhpBar.value = player.HP / 10;
                hpBar.value = player.HP / 10;
            }
            player.calories -= 100;
            calories.text = player.calories.ToString();
        }
        
    }
}
