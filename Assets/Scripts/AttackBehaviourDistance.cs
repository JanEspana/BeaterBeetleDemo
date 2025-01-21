using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackBehaviourDistance : AttackBehaviourGeneric
{
    public ParticleSystem sprayAttack;
    float attackCooldown = 3f;
    public override void Attack()
    {
        if (attackCooldown == 3f && player.HP > 0)
        {
            sprayAttack.Play();
            attackCooldown = 0;
            StartCoroutine(StopAttack());
        }
        else if (player.HP > 0 && attackCooldown != 3)
        {
            StartCoroutine(ResetCooldown());
        }
    }
    IEnumerator StopAttack()
    {
        yield return new WaitForSeconds(0.5f);
        sprayAttack.Stop();
    }
    IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(3);
        attackCooldown = 3;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sprayAttack.Stop();
        }
    }
}