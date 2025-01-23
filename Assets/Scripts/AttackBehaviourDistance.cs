using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackBehaviourDistance : AttackBehaviourGeneric
{
    public ParticleSystem sprayAttack;
    public Collider sprayCollider;
    public override void Attack()
    {
        if (attackCooldown >= 3f && player.HP > 0)
        {
            sprayCollider.enabled = true;
            attackCooldown = 0;
            sprayAttack.Play();
            StartCoroutine(StopAttack());
        }
        else if (player.HP > 0 && attackCooldown < 3)
        {
            attackCooldown += Time.deltaTime;
        }
    }
    IEnumerator StopAttack()
    {
        yield return new WaitForSeconds(0.5f);
        sprayCollider.enabled = false;
        sprayAttack.Stop();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sprayAttack.Stop();
        }
    }
}