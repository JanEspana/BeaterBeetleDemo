using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "StunSO", menuName = "States/StunSO", order = 0)]
public class StunSO : StatesSO
{
    public override void OnStateEnter(EnemyController ec)
    {
        ec.chase.enabled = false;
        ec.gameObject.GetComponent<Renderer>().material.color = Color.red;
        ec.StartCoroutine(Stun(ec));
    }

    public override void OnStateExit(EnemyController ec)
    {
    }

    public override void OnStateUpdate(EnemyController ec)
    {
    }
    IEnumerator Stun(EnemyController ec)
    {
        yield return new WaitForSeconds(ec.stun);
        ec.chase.enabled = true;
        ec.gameObject.GetComponent<Renderer>().material.color = ec.mat.color;
        if (!ec.isDistance)
        {
            ec.GoToState<ChaseSO>();
        }
        else
        {
            Vector3 distance = ec.target.transform.position - ec.transform.position;
            if (distance.magnitude < 4.5f)
            {
                ec.GoToState<AttackSO>();
            }
            else
            {
                ec.GoToState<ChaseSO>();
            }
        }
    }
}
