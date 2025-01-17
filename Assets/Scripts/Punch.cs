using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : AttackGeneric
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == rivalTag)
        {
            other.gameObject.GetComponent<Character>().hasKnockback = false;
            other.gameObject.GetComponent<Character>().TakeDamage(dmg);
        }
    }
}
