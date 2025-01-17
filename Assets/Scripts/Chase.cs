using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public float speed;
    public float range;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void ChaseTarget(Transform target, Transform self)
    {
        //rb.MovePosition(Vector3.MoveTowards(self.position, target.position, speed * Time.deltaTime));
        Vector3 direction = target.position - self.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        self.rotation = rotation;
        rb.velocity = direction.normalized * speed;
    }
    public void StopChase()
    {
        rb.velocity = Vector3.zero;
    }
}
