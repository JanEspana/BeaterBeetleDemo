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
        hpBar.value = GameManager.instance.player.GetComponent<Player>().HP/10;
        calories.text = GameManager.instance.player.GetComponent<Player>().calories.ToString();
    }
    public void NextBattle()
    {
        GameManager.instance.StartRound();
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
