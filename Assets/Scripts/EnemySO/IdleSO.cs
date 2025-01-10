using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleSO", menuName = "States/IdleSO")]
public class IdleSO : StatesSO
{
    public override void OnStateEnter(EnemyController ec)
    {
        ec.StartCoroutine(StartChasing(ec));
    }

    public override void OnStateExit(EnemyController ec)
    {
    }

    public override void OnStateUpdate(EnemyController ec)
    {
    }
    IEnumerator StartChasing(EnemyController ec)
    {
        yield return new WaitForSeconds(2);
        ec.GoToState<ChaseSO>();
    }
}
