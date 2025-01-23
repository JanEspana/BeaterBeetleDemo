using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBehaviourGeneric : MonoBehaviour
{
    public Player player;
    public float attackCooldown;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public abstract void Attack();
}
