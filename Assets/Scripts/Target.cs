using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // reference to target's initial health. 
    public int health = 3;
    // reference to amount of damage target can receive in a hit.
    int damage = 1;
    
    public void DestroyTarget()
    {
        // health decreases with each damage.
        health -= damage;
        if (health <= 0)
        {
            // target gets destroyed when there is no health left.
            Destroy(this.gameObject);

        }
    }
}
