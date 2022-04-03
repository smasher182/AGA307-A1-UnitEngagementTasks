using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    // reference to projectile in the inspector.
    // turned into an array after adding more projectiles.
    public GameObject[] projectilePrefab;
    // reference to projectile speed in the inspector.
    public float projectileSpeed = 2000f;
    // reference to firingPoint in the inspector.
    public Transform firingPoint;
    // reference to array of weapons.
    public GameObject[] weapons;


    private void Start()
    {
        // initializes the first weapon in the array.
        ChangeWeapon(0);
        
    }

    void Update()
    {
        /* revised the method after adding more projectiles.
        if (Input.GetButtonDown("Fire1"))
        {
            // reference to projectile being instantiated.
            GameObject projectileInstance;
            // instantiates projectile at the position and rotation of this transform.
            projectileInstance = Instantiate(projectilePrefab, transform.position, transform.rotation);
            // moves the instanced projectile forward along the current object's forward axis.
            projectileInstance.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
            Destroy(projectileInstance, 3);
        }
        */
        // gets first weapon in the array when num key 1 is pressed.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapon(0);
            // prints the name of selected weapon to the console.
            Debug.Log("Weapon selected is " + weapons[0].name);
        }
        // gets second weapon in the array when num key 2 is pressed.
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeapon(1);
            // prints the name of selected weapon to the console.
            Debug.Log("Weapon selected is " + weapons[1].name);
        }
        // gets third weapon in the array when num key 3 is pressed.
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeWeapon(2);
            // prints the name of selected weapon to the console.
            Debug.Log("Weapon selected is " + weapons[2].name);
        }

        /*if (Input.GetButtonDown("Fire1"))
        {
            if ((weapons[0] == true))
            {
                FireProjectile(0);
            }

            if ((weapons[1] == true))
            {
                FireProjectile(1);
            }
            if ((weapons[2] == true))
            {
                FireProjectile(2);
            }
        }
        */

        if ((weapons[0] == true) && Input.GetButtonDown("Fire1"))
        {
            FireProjectile(0);
        }

       /* if ((weapons[1] == true) && Input.GetButtonDown("Fire1"))
        {
            FireProjectile(1);
        }

        if((weapons[2] == true) && Input.GetButtonDown("Fire1"))
        {
            FireProjectile(2);
        }
       */
    }
    void ChangeWeapon(int _weapon)
    {
        // loops from 0 until the length of weapons array.
        for (int i = 0; i < weapons.Length; i++)
        {
            // deactivates all weapons at the beginning.
            weapons[i].SetActive(false);
            // activates the selected weapon.
            weapons[_weapon].SetActive(true);
        }
    }
    void FireProjectile(int _projectile)
    {
        // reference to projectile to be instantiated.
        GameObject projectileInstance;
        // instantiates projectile at the position and rotation of this transform.
        projectileInstance = Instantiate(projectilePrefab[_projectile], transform.position, transform.rotation);
        // moves the instanced projectile forward along the current object's z-axis.
        projectileInstance.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
        // destroys each projectile instance after 3 seconds.
        Destroy(projectileInstance, 3);

        

    }
}
