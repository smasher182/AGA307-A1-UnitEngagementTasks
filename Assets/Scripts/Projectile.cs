using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        // checks if the collided gameobject has the tag "Target".
        if (collision.gameObject.CompareTag("Target"))
        {


            // destroys the collided gameobject in 1 sec.
            // Destroy(collision.gameObject, 1);

            collision.gameObject.GetComponent<Target>().Hit();
            // destroys the collider gameobject itself.
            Destroy(this.gameObject);


        }
    }


}
