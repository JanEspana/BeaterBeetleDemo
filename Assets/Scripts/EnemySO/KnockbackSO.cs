using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "KnockbackSO", menuName = "States/KnockbackSO", order = 0)]
public class KnockbackSO : StatesSO
{
    public override void OnStateEnter(EnemyController ec)
    {
        ec.chase.enabled = false;
        //ec.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Rigidbody rb = ec.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        Knockback(ec, rb);
    }

    public override void OnStateExit(EnemyController ec)
    {
        ec.chase.enabled = true;
    }

    public override void OnStateUpdate(EnemyController ec)
    {
        ec.StartCoroutine(CheckGround(ec.GetComponent<Rigidbody>(), ec.gameObject, ec));

    }
    void Knockback(EnemyController ec, Rigidbody rb)
    {
        rb.AddForce(Vector3.up * ec.knockback, ForceMode.Impulse);
        rb.AddForce(-ec.transform.forward * ec.knockback, ForceMode.Impulse);
    }
    IEnumerator CheckGround(Rigidbody rb, GameObject self, EnemyController ec)
    {
        yield return new WaitForSeconds(0.1f);
        float speedY = rb.velocity.y;
        RaycastHit hit;
        if (Physics.Raycast(self.transform.position, Vector3.down, out hit, 1.1f) && speedY == 0)
        {
            ec.GoToState<StunSO>();
        }
    }
}
