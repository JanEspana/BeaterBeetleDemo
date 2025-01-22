using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void NextBattle()
    {
        GameManager.instance.StartRound();
    }
}
