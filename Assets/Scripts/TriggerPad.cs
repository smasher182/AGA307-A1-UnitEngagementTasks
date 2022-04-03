using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : MonoBehaviour
{
    // reference to sphere in the inspector.
    public GameObject sphere;
    // reference to original scale of sphere.
    Vector3 startScale;
    

    private void Start()
    {
        // starts with original scale for the sphere.
        startScale = sphere.transform.localScale;
        

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // checks if the collider object has the tag "Player".
            if (other.CompareTag("Player"))
            {
                // changes the sphere colour to green.
                sphere.GetComponent<Renderer>().material.color = Color.green;

            }
        }

        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.CompareTag("Player"))
            {
                // increases the sphere scale by 0.01 on all axis
                sphere.transform.localScale += Vector3.one * 0.01f;
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // changes the sphere colour to original color.
            sphere.GetComponent<Renderer>().material.color = Color.yellow;
            // reverts the sphere size back to original.
            sphere.transform.localScale = startScale;


        }
    }
}


