using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantisAnim : AnimGeneric
{
    public AttackBehaviourSlash abs;
    public override void SpecificAnim()
    {
        currentState = GetComponent<EnemyController>().currentState;
        if (currentState.GetType() == typeof(AttackSO) && abs.attackCooldown <= 0)
        {
            if (abs.actualCut)
            {
                anim.SetTrigger("LowCut");
            }
            else
            {
                anim.SetTrigger("CrossCut");
            }
        }
    }
}