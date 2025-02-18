using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HardcorePlayer", menuName = "Upgrades/HardcorePlayer", order = 1)]
public class HardcorePlayer : UpgradeSO
{
    public float attackMultiplier = 5;
    public float hpMultiplier = 0.2f;
    public MenuManager menuManager;
    public GameObject player;

    public override void ApplyUpgrade()
    {
        menuManager = UpgradeManager.instance.menuManager;
        player = UpgradeManager.instance.player;
        player.GetComponent<AttackManager>().leftPunch.GetComponent<Punch>().dmg *= attackMultiplier;
        player.GetComponent<AttackManager>().rightPunch.GetComponent<Punch>().dmg *= attackMultiplier;
        menuManager.maxHP *= hpMultiplier;
        menuManager.healedHP = menuManager.maxHP;
        player.GetComponent<Player>().HP = menuManager.maxHP;
    }
}
