using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBehaviourGeneric : MonoBehaviour
{
    public Player player;
    public float attackCooldown;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Debug.Log(player);
    }
    public abstract void Attack();
}
