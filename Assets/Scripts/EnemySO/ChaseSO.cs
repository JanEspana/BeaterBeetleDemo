using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChaseSO", menuName = "States/ChaseSO")]
public class ChaseSO : StatesSO
{
    public override void OnStateEnter(EnemyController ec)
    {
    }
    public override void OnStateExit(EnemyController ec)
    {
        ec.chase.StopChase();
    }
    public override void OnStateUpdate(EnemyController ec)
    {
        Debug.Log("Chasing");
        ec.chase.ChaseTarget(ec.player.transform, ec.transform);
    }
}