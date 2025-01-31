using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviourSlash : AttackBehaviourGeneric
{
    public GameObject lowCut, crossCut;
    bool actualCut, isAttacking;
    public override void Attack()
    {
        if (actualCut && player.HP > 0)
        {
            Slash(lowCut, lowCut.GetComponent<BoxCollider>());
        }
        else if (!actualCut && player.HP > 0)
        {
            Slash(crossCut, crossCut.GetComponent<BoxCollider>());
        }
        else
        {
            gameObject.GetComponent<EnemyController>().GoToState<IdleSO>();
        }
    }
    void Slash(GameObject cut, BoxCollider collider)
    {
        if (!isAttacking)
        {
            isAttacking = true;
            collider.enabled = true;
            StartCoroutine(ResetCut(cut, collider));
        }
    }
    IEnumerator ResetCut(GameObject punch, BoxCollider collider)
    {
        yield return new WaitForSeconds(attackCooldown);
        collider.enabled = false;
        isAttacking = false;
        actualCut = !actualCut;
    }
}
