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
            
            if (rivalTag == "Player" && !other.gameObject.GetComponent<Player>().isBlocking)
            {
                other.gameObject.GetComponent<Character>().TakeDamage(dmg);
            }
            else if (rivalTag == "Enemy")
            {
                other.gameObject.GetComponent<Character>().TakeDamage(dmg);
            }
        }
    }
}
