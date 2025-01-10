using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "StunSO", menuName = "States/StunSO", order = 0)]
public class StunSO : StatesSO
{
    public override void OnStateEnter(EnemyController ec)
    {
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
        yield return new WaitForSeconds(0.1f);
        ec.gameObject.GetComponent<Renderer>().material.color = Color.white;
        ec.GoToState<ChaseSO>();
    }
}
