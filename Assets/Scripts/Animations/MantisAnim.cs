using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MantisAnim : AnimGeneric
{
    public AttackBehaviourSlash abs;
    private void Update()
    {
        currentState = GetComponent<EnemyController>().currentState;
        if (currentState.GetType() == typeof(AttackSO))
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
