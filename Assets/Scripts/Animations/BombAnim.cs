using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAnim : AnimGeneric
{
    public override void SpecificAnim()
    {
        currentState = GetComponent<EnemyController>().currentState;
        if (currentState.GetType() == typeof(AttackSO))
        {
            anim.SetTrigger("Attack");
        }
    }
}
