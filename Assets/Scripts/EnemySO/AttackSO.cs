using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackSO", menuName = "States/AttackSO")]
public class AttackSO : StatesSO
{
    public override void OnStateEnter(EnemyController ec)
    {
        Debug.Log(">:(");
        if (ec.gameObject.GetComponent<AttackBehaviourSlash>() != null)
        {
            //get child object
            ec.gameObject.GetComponent<AttackBehaviourSlash>().lowCut.SetActive(true);
            ec.gameObject.GetComponent<AttackBehaviourSlash>().crossCut.SetActive(true);
        }
    }

    public override void OnStateExit(EnemyController ec)
    {
        if (ec.gameObject.GetComponent<AttackBehaviourSlash>() != null)
        {
            //get child object
            ec.gameObject.GetComponent<AttackBehaviourSlash>().lowCut.SetActive(false);
            ec.gameObject.GetComponent<AttackBehaviourSlash>().crossCut.SetActive(false);
        }
    }

    public override void OnStateUpdate(EnemyController ec)
    {
        ec.attack.Attack();

    }
}
