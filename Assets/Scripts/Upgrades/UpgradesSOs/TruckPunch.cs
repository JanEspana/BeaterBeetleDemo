using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TruckPunch", menuName = "Upgrades/TruckPunch")]
public class TruckPunch : UpgradeSO
{
    public float damageMultiplier = 2;
    public float cooldown = 0.6f;

    public override void ApplyUpgrade()
    {
        UpgradeManager.instance.player.GetComponent<AttackManager>().leftPunch.GetComponent<Punch>().dmg *= damageMultiplier;
        UpgradeManager.instance.player.GetComponent<AttackManager>().rightPunch.GetComponent<Punch>().dmg *= damageMultiplier;
        UpgradeManager.instance.player.GetComponent<AttackManager>().attackCooldown = cooldown;
    }
}
