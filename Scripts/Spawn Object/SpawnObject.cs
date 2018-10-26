using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawn cube in random spawn point
public class SpawnObject : MonoBehaviour {

    public GameObject cube;
    // Array of spawn points
    public Transform[] spawnPoints;

    // Called when script is enabled
    void Start ()
    {
        // Get random spawn point and spawn cube
        int randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(cube, spawnPoints[randomSpawnPoint]);
	}
}
