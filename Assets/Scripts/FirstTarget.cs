using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTarget : MonoBehaviour
{
    // reference to target's initial health. 
    public int health = 3;
    // reference to amount of damage target can receive in a hit.
    int damage = 1;

    public void Kill()
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
