using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedDemon", menuName = "Upgrades/SpeedDemon")]
public class SpeedDemonSO : UpgradeSO
{
    public float speedMultiplier = 1.5f;

    public override void ApplyUpgrade()
    {
        UpgradeManager.instance.player.GetComponent<Movement>().speed *= speedMultiplier;
    }
}
