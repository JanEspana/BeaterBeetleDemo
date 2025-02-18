using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scavenger", menuName = "Upgrades/Scavenger")]
public class Scavenger : UpgradeSO
{
    public float extraCaloriesPercent = 0.2f;
    public override void ApplyUpgrade()
    {
        UpgradeManager.instance.player.GetComponent<Player>().gainedCalories += UpgradeManager.instance.player.GetComponent<Player>().gainedCalories * extraCaloriesPercent;
    }
}
