using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackSO", menuName = "States/AttackSO")]
public class AttackSO : StatesSO
{
    public override void OnStateEnter(EnemyController ec)
    {
        Debug.Log(">:(");

    }

    public override void OnStateExit(EnemyController ec)
    {
    }

    public override void OnStateUpdate(EnemyController ec)
    {
        ec.attack.Attack();

    }
}
