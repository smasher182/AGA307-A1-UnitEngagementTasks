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
    // reference to basic speed of targets.
    float baseSpeed = 2f;
    // reference to current speed of target.
    public float mySpeed = 4f;







    private void Start()
    {
        SetUp();
        // finds the TargetManger script.
        _TM = FindObjectOfType<TargetManager>();

        // removed after adding random move coroutine.
        //StartCoroutine(Move());

        StartCoroutine(MoveRandom(_TM.spawnPoints[Random.Range(0, _TM.spawnPoints.Length)]));

    }

void SetUp()
    {
        switch (targetSize)
        {
            case TargetSize.SMALL:
                // changes material color to red.
                GetComponent<Renderer>().material.color = Color.red;
                // decreases object scale by half at the start.
                transform.localScale = Vector3.one * scaleFactor / 1.4f;
                // increases speed by 10.
                mySpeed = baseSpeed * 10f;

                break;

            case TargetSize.MEDIUM:
                // changes material color to red.
                GetComponent<Renderer>().material.color = Color.yellow;
                // keeps the same scale.
                transform.localScale = Vector3.one * scaleFactor * 1f;
                // keeps the same speed.
                mySpeed = baseSpeed * 1f;

                break;

            case TargetSize.LARGE:
                // changes material color to red.
                GetComponent<Renderer>().material.color = Color.green;
                // increases object scale by twice the initial size at the start.
                transform.localScale = Vector3.one * scaleFactor * 1.4f;
                // decreases the speed by 5.
                mySpeed = baseSpeed * 5f;

                break;

           
            default:
                transform.localScale = Vector3.one;
                mySpeed = baseSpeed;
                break;

        }

    }

    /* IEnumerator Move()
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
    */

    IEnumerator MoveRandom(Transform _newPos)
    {
        // while the distance between the current position and the destination position is greater than 0.1f then execute...
        while (Vector3.Distance(transform.position, _newPos.position) > 0.1f)
        {
            // gives the new transform position.
            transform.position = Vector3.MoveTowards(transform.position, _newPos.position, Time.deltaTime * mySpeed);
            //  rotates towards the new position.
            transform.rotation = Quaternion.LookRotation(_newPos.position);
            yield return null;
        }
        // waits for 3 seconds after the coroutine has run.
        yield return new WaitForSeconds(3);
        // Debug.Log("Waited for 3 secs");
        // moves the target randomly between 0 and spawnPoints length.
        StartCoroutine(MoveRandom(_TM.spawnPoints[Random.Range(0, _TM.spawnPoints.Length)]));
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
