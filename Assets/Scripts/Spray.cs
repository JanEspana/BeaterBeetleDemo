using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SprayDamage : AttackGeneric
{
    bool isAttacking = false;
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(rivalTag))
        {
            if (!isAttacking)
            {
                dmg = 1;
                isAttacking = true;
                Debug.Log("Spray hit " + dmg);
            }
            else
            {
                dmg = 0;
            }
            ParticleSystem particleSystem = GetComponent<ParticleSystem>();
            other.gameObject.GetComponent<Player>().TakeDamage(dmg);
            StartCoroutine(ResetAttack());
        }
    }
    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(3);
        isAttacking = false;
    }
}
