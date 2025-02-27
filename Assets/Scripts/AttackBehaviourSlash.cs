using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviourSlash : AttackBehaviourGeneric
{
    public GameObject lowCut, crossCut, warningSphere;
    public bool actualCut, isAttacking;
    public override void Attack()
    {
        if (attackCooldown <= 0)
        {


            if (actualCut && player.HP > 0)
            {
                Slash(lowCut, lowCut.GetComponent<BoxCollider>());
            }
            else if (!actualCut && player.HP > 0)
            {
                Slash(crossCut, crossCut.GetComponent<BoxCollider>());
            }
            else if (player.HP <= 0)
            {
                gameObject.GetComponent<EnemyController>().GoToState<IdleSO>();
            }
        }
        else
        {
            attackCooldown -= Time.deltaTime;
        }
    }
    void Slash(GameObject cut, BoxCollider collider)
    {
        if (!isAttacking)
        {
            cut.GetComponent<Punch>().originalPosition = cut.transform.position;
            isAttacking = true;
            collider.enabled = true;
            cut.GetComponent<Rigidbody>().velocity = cut.transform.forward * 5;
            StartCoroutine(ResetCut(cut, collider));
        }
    }
    IEnumerator ResetCut(GameObject cut, BoxCollider collider)
    {
        yield return new WaitForSeconds(0.5f);
        cut.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cut.transform.position = cut.GetComponent<Punch>().originalPosition;
        collider.enabled = false;
        isAttacking = false;
        actualCut = Random.Range(0, 2) == 0;
        attackCooldown = 3;
        if (actualCut)
        {
            warningSphere.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            warningSphere.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}
