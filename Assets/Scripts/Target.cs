using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // reference to TargetManager script.
    TargetManager _TM;

    // reference to target's initial health. 
    public int health = 3;
    // reference to amount of damage target can receive in a hit.
    int damage = 1;
    // reference to different target sizes 
    public TargetSize targetSize;
    // reference to target in the scene.
    public GameObject target;
    // reference to basic scale of objects in the scene.
    float scaleFactor = 1;

    // reference to max distance the target can move.
    float moveDistance = 2000;
   





    private void Start()
    {
        SetUp();
        // finds the TargetManger script.
        _TM = FindObjectOfType<TargetManager>();

        StartCoroutine(Move());

    }

    void SetUp()
    {
        switch (targetSize)
        {
            case TargetSize.SMALL:
                // decreases object scale by half at the start.
                transform.localScale = Vector3.one * scaleFactor / 1.4f;
                break;

            case TargetSize.MEDIUM:               
                // keeps the same scale.
                transform.localScale = Vector3.one * scaleFactor * 1f;               
                break;

            case TargetSize.LARGE:               
                // increases object scale by twice the initial size at the start.
                transform.localScale = Vector3.one * scaleFactor * 1.4f;               
                break;

           
            default:
                transform.localScale = Vector3.one;
                break;

        }

    }

    IEnumerator Move()
    {
        // loops from 0 until the movedistance.
        for (int i = 0; i < moveDistance; i++)
        {
            // moves the object in forward direcrtion.
            transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;

        }
        // moves the object in the opposite direction.
        transform.Rotate(Vector3.up * 180);
        // waits for 1 sec after the coroutine is run.
        yield return new WaitForSeconds(1);
        StartCoroutine(Move());
    }

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
