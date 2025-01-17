using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public GameObject leftPunch, rightPunch, horn;
    BoxCollider leftPunchCollider, rightPunchCollider, hornCollider;
    bool isAttacking = false;
    public float attackCooldown = 0.3f, specialCooldown = 3f;
    public bool actualPunch = true;

    private void Awake()
    {
        leftPunchCollider = leftPunch.GetComponent<BoxCollider>();
        rightPunchCollider = rightPunch.GetComponent<BoxCollider>();
        hornCollider = horn.GetComponent<BoxCollider>();


        leftPunchCollider.enabled = false;
        rightPunchCollider.enabled = false;
        hornCollider.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (actualPunch)
            {
                AttackAnim(leftPunch, leftPunchCollider);
            }
            else
            {
                AttackAnim(rightPunch, rightPunchCollider);
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && horn.GetComponent<HornAttack>().isRecharged)
        {
            AttackAnim(horn, hornCollider);
            horn.GetComponent<HornAttack>().isRecharged = false;
            StartCoroutine(ResetSpecial(horn));
        }
    }

    void AttackAnim(GameObject hit, BoxCollider collider)
    {
        if (!isAttacking)
        {
            isAttacking = true;
            collider.enabled = true;
            hit.transform.position = hit.transform.position - hit.transform.right * 0.5f;
            StartCoroutine(ResetPosition(hit, collider));
        }
    }
    IEnumerator ResetPosition(GameObject hit, BoxCollider collider)
    {
        yield return new WaitForSeconds(attackCooldown);
        collider.enabled = false;
        hit.transform.position = hit.transform.position + hit.transform.right * 0.5f;
        isAttacking = false;
        actualPunch = !actualPunch;
    }
    IEnumerator ResetSpecial(GameObject special)
    {
        yield return new WaitForSeconds(specialCooldown);
        special.GetComponent<AttackGeneric>().isRecharged = true;
    }
}
