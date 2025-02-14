using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public List<UpgradeSO> upgrades;
    public static UpgradeMenu instance;

    public void Start()
    {
        
    }
    //elige un upgrade aleatorio y lo aplica
    public void ApplyRandomUpgrade()
    {
        int randomIndex = Random.Range(0, upgrades.Count);
        upgrades[randomIndex].ApplyUpgrade();
    }
}
