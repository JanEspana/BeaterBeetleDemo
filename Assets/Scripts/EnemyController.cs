using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Character
{
    public StatesSO currentState;
    public Chase chase;
    public AttackBehaviourEnemy attack;
    public GameObject player;
    public Material mat;
    public float stun;
    // Start is called before the first frame update

    public void Awake()
    {
        chase = GetComponent<Chase>();
        attack = GetComponent<AttackBehaviourEnemy>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        currentState.OnStateEnter(this);
    }
    private void FixedUpdate()
    {
        currentState.OnStateUpdate(this);
    }

    public void GoToState<T>() where T : StatesSO
    {
        if (currentState.states.Find(state => state is T))
        {
            currentState.OnStateExit(this);
            currentState = currentState.states.Find(state => state is T);
            currentState.OnStateEnter(this);

        }
    }
    public override void CheckIfAlive(bool hasKnockback)
    {
        if (HP <= 0)
        {
            Die();
        }
        else if (hasKnockback)
        {
            GoToState<KnockbackSO>();
        }
        else
        {
            GoToState<StunSO>();
        }
    }
    public override void Die()
    {
        HP = 0;
        GameManager.instance.enemy = null;
        GoToState<DieSO>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GoToState<AttackSO>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GoToState<ChaseSO>();
        }
    }
}