using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackGeneric : MonoBehaviour
{
    public float dmg;
    public string rivalTag;
    public bool isRecharged = true;

    public abstract void OnTriggerEnter(Collider other);
}
