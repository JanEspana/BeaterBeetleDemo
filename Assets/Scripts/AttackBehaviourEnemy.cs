using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviourEnemy : MonoBehaviour
{
    public GameObject leftPunch, rightPunch;
    public Player player;
    bool actualPunch, isAttacking;
    float attackCooldown = 0.3f;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public void Attack()
    {
        if (actualPunch && player.HP > 0)
        {
            BasicAttack(leftPunch, leftPunch.GetComponent<BoxCollider>());
        }
        else if (!actualPunch && player.HP > 0)
        {
            BasicAttack(rightPunch, rightPunch.GetComponent<BoxCollider>());
        }
        else
        {
            gameObject.GetComponent<EnemyController>().GoToState<IdleSO>();
        }
    }
    void BasicAttack(GameObject punch, BoxCollider collider)
    {
        if (!isAttacking)
        {
            isAttacking = true;
            collider.enabled = true;
            punch.transform.position = punch.transform.position - punch.transform.right * 0.5f;
            StartCoroutine(ResetPosition(punch, collider));
        }
    }
    IEnumerator ResetPosition(GameObject punch, BoxCollider collider)
    {
        yield return new WaitForSeconds(attackCooldown);
        collider.enabled = false;
        punch.transform.position = punch.transform.position + punch.transform.right * 0.5f;
        isAttacking = false;
        actualPunch = !actualPunch;
    }
}
