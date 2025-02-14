using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public UpgradeSO upgrade;

    public void SelectRandomUpgrade()
    {
        upgrade = UpgradeManager.instance.upgrades[Random.Range(0, UpgradeManager.instance.upgrades.Count)];
        //elimina o upgrade selecionado da lista
        UpgradeManager.instance.upgrades.Remove(upgrade);
        gameObject.GetComponent<Image>().sprite = upgrade.icon;
        gameObject.GetComponentInChildren<TextMeshPro>().text = upgrade.upgradeName;
    }
    public void ApplyUpgrade()
    {
        upgrade.ApplyUpgrade();
    }
}
