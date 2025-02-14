using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nutritionist", menuName = "Upgrades/Nutritionist")]
public class Nutritionist : UpgradeSO
{
    public float healthRegen;
    public MenuManager menuManager;
    public override void ApplyUpgrade()
    {
        healthRegen = menuManager.maxHP;
        menuManager.healedHP = healthRegen;
    }

}
