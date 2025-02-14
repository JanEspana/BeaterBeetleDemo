using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DieSO", menuName = "States/DieSO")]
public class DieSO : StatesSO
{
    public override void OnStateEnter(EnemyController ec)
    {
        if (ec.GetComponent<Player>() != null)
        {
            ec.target.GetComponent<Player>().calories += 100;

        }
        if (!ec.isAnt)
        {
            GameManager.instance.menuManager.ActiveCanvas();
        }
        Destroy(ec.gameObject);
    }
    public override void OnStateExit(EnemyController ec)
    {
    }

    public override void OnStateUpdate(EnemyController ec)
    {
    }
}
