using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetSize { SMALL, MEDIUM, LARGE }

public class TargetManager : Singleton<TargetManager>
{
    // reference to array of spawn points in the scene. 
    public Transform[] spawnPoints;
    // reference to array of available target types in the scene.
    public GameObject[] targetTypes;
    // reference to list of targets in the scene.
    public List<GameObject> targets;

    void Update()
    {
        // executes spawnRandom function with a key(I) press.
        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnRandom();
        }

    }
    void SpawnRandom()
    {
        // loops from 0 until the length of spawnPoints array.
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            // finds a random spawn point between 0 and spawn points length.
            int rndSpawn = Random.Range(0, spawnPoints.Length);
            // finds a random target type between 0 and target types length.
            int rndTarget = Random.Range(0, targetTypes.Length);
            // instantiates random target types and random spawn points.
            GameObject go = Instantiate(targetTypes[rndTarget], spawnPoints[rndSpawn]);
            // adds new target created to the targets list.

            targets.Add(go);
            Debug.Log("Target count is:" + targets.Count);



        }

    }

    public void DestroyTarget(GameObject _target)
    {
        // destroys the target.
        Destroy(_target);
        // removes targets from the targets list.
        targets.Remove(_target);
        //Debug.Log("Targets remaining is:" + targets.Count);
    }

    private void OnEnable()
    {
        // subscribes to the event call.
        //calls DestroyTarget function after the GameEvents has happened.
        GameEvents.OnTargetDestroyed += DestroyTarget;
    }
    private void OnDisable()
    {
        // unsubscribes to the event call.
        //calls DestroyTarget function after the GameEvents has happened.
        GameEvents.OnTargetDestroyed -= DestroyTarget;
    }
}
