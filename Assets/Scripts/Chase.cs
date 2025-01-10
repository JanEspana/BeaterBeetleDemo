using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public float speed = 1f;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void ChaseTarget(Transform target, Transform self)
    {
        rb.MovePosition(Vector3.MoveTowards(self.position, target.position, speed * Time.deltaTime));
    }
    public void StopChase()
    {
        rb.velocity = Vector3.zero;
    }
}
