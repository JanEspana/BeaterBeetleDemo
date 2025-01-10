using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject leftPunch, rightPunch;
    BoxCollider leftPunchCollider, rightPunchCollider;
    bool isAttacking = false;
    public float attackCooldown = 0.3f;
    public bool actualPunch = true;

    private void Awake()
    {
        leftPunchCollider = leftPunch.GetComponent<BoxCollider>();
        rightPunchCollider = rightPunch.GetComponent<BoxCollider>();

        leftPunchCollider.enabled = false;
        rightPunchCollider.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (actualPunch)
            {
                BasicAttack(leftPunch, leftPunchCollider);
            }
            else
            {
                BasicAttack(rightPunch, rightPunchCollider);
            }
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
