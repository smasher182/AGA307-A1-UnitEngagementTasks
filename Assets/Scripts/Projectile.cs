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
            // removed after week 02 challenge

            // destroys the collided gameobject in 1 sec.
            //Destroy(collision.gameObject, 1);  

            // calls the KillTarget function from the Target script.
            collision.gameObject.GetComponent<Target>().Hit();
            // destroys the collider gameobject itself.
            Destroy(this.gameObject);


        }
        if (collision.gameObject.CompareTag("TargetOld"))
        {
            // calls the Kill function from the FirstTarget script.
            collision.gameObject.GetComponent<FirstTarget>().Kill();
            // destroys the collider gameobject itself.
            Destroy(this.gameObject);

        }


    }


}
