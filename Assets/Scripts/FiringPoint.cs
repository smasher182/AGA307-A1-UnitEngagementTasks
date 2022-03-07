using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    // reference to projectile in the inspector.
    public GameObject projectilePrefab;
    // reference to projectile speed in the inspector.
    public float projectileSpeed = 2000f;
    // reference to firingPoint in the inspector.
    public Transform firingPoint;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // reference to projectile being instantiated.
            GameObject projectileInstance;
            // instantiates projectile at the position and rotation of this transform.
            projectileInstance = Instantiate(projectilePrefab, transform.position, transform.rotation);
            // moves the instanced projectile forward along the current object's forward axis.
            projectileInstance.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);        
        }
    }
}
