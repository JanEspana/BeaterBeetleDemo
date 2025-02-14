using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThousandNeedles", menuName = "Upgrades/ThousandNeedles")]
public class ThousandNeedles : UpgradeSO
{
    public float damageMultiplier = 0.5f;
    public float cooldown = 0.15f;

    public override void ApplyUpgrade()
    {
        UpgradeManager.instance.player.GetComponent<AttackManager>().leftPunch.GetComponent<Punch>().dmg *= damageMultiplier;
        UpgradeManager.instance.player.GetComponent<AttackManager>().rightPunch.GetComponent<Punch>().dmg *= damageMultiplier;
        UpgradeManager.instance.player.GetComponent<AttackManager>().attackCooldown = cooldown;
    }
}
