using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviourJump : AttackBehaviourGeneric
{
    public Rigidbody rb;
    float jumpForce;
    bool isGrounded = false;
    public bool isInRange = false;
    Transform targetPosition;
    public override void Attack()
    {
        if (!isInRange)
        {
            if (attackCooldown <= 0 && player.HP > 0)
            {
                targetPosition = player.transform;
                transform.LookAt(targetPosition);
                jumpForce = CalculateJumpForce(targetPosition, transform);
                rb.AddForce(transform.forward * jumpForce);
                rb.AddForce(transform.up * jumpForce); attackCooldown = 3;
            }
            else if (player.HP > 0 && attackCooldown > 0)
            {
                attackCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (attackCooldown <= 0 && player.HP > 0 && isGrounded)
            {
                player.TakeDamage(1);
                attackCooldown = 3;
            }
            else if (player.HP > 0 && attackCooldown > 0)
            {
                attackCooldown -= Time.deltaTime;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isGrounded && collision.gameObject.tag == "Player")
        {
            player.TakeDamage(2);
        }
        isGrounded = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = true;
        }
    }
    float CalculateJumpForce(Transform targetPos, Transform selfPos)
    {
        return Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * (targetPos.position.y - selfPos.position.y)) / Mathf.Sin(45 * Mathf.Deg2Rad);
    }
}
