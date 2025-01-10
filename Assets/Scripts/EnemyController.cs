using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float HP;
    public StatesSO currentState;
    public Chase chase;
    public GameObject player;
    // Start is called before the first frame update

    public void GoToState<T>() where T : StatesSO
    {
        if (currentState.states.Find(state => state is T))
        {
            currentState.OnStateExit(this);
            currentState = currentState.states.Find(state => state is T);
            currentState.OnStateEnter(this);
        }
    }
    public void CheckIfAlive()
    {
        if (HP <= 0)
        {
            HP = 0;
            GoToState<DieSO>();
        }
        else
        {
            GoToState<StunSO>();
        }
    }
    public void TakeDamage(float dmg)
    {
        HP -= dmg;
        CheckIfAlive();
    }
}
