using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad2 : MonoBehaviour
{
    // reference to sphere in the inspector.
    public GameObject sphere;
    // reference to original color of sphere.
    Color originalColor;

    // reference to the layer mask  that is used to selectively ignore Colliders when casting a ray.
    public LayerMask layerMask;

    private void Start()
    {
        // starts with original color for the sphere. 
        originalColor = sphere.GetComponent<Renderer>().material.color;

    }

    void OnTriggerEnter(Collider other)
    {
        // checks if the collider object has the tag "Player".
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player has entered.");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CastRay();

            if (Input.GetKeyDown(KeyCode.E))
            {
                // turns off the visibility of sphere.
                sphere.GetComponent<Renderer>().enabled = false;
            }
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // reverts the sphere color to original.
            sphere.GetComponent<Renderer>().material.color = originalColor;
            // turns on the visibility of sphere.
            sphere.GetComponent<Renderer>().enabled = true;
        }
    }

    void CastRay()
    {
        // returns a ray going from camera through a viewport point.
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        // stores the raycast hit info.
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10, layerMask))
        {
            //Debug.Log("Hit");
            // raycast hit changes the collider color to black.
            hit.collider.GetComponent<Renderer>().material.color = Color.grey;


        }
    }



}
