using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrades/Upgrade")]
public class UpgradeSO : ScriptableObject
{
    public Image icon;
    public string upgradeName;

    public void ApplyUpgrade()
    {
        Debug.Log("Applying upgrade: " + upgradeName);
    }
}
