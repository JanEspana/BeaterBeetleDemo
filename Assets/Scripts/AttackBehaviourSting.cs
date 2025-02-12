using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviourSting : AttackBehaviourGeneric
{
    public Rigidbody rb;
    Transform targetPosition;
    public override void Attack()
    {
        if (attackCooldown >= 3f && player.HP > 0)
        {
            targetPosition = player.transform;
            transform.LookAt(targetPosition);
            rb.AddForce(transform.forward * 1000);
            attackCooldown = 0;

        }
        else if (player.HP > 0 && attackCooldown < 5)
        {
            attackCooldown += Time.deltaTime;
        }
    }
    IEnumerator RecoverPosition()
    {
        yield return new WaitForSeconds(2);
        //move up
        rb.velocity = new Vector3(0, 2, 0);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(3);
        }
        rb.velocity = Vector3.zero;
        StartCoroutine(RecoverPosition());
    }
}
