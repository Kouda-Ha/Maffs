using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SpawnObject script. Spawns an object of choice at a specified transform/location
// when you trigger the collision/box collider.
public class SpawnObject : MonoBehaviour
{
    public Transform spawnTransform;
    public GameObject spawnObject;

    // On trigger enter, spawn the object at it's specified transform
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(spawnObject, spawnTransform.position, spawnTransform.rotation);
        
    }

}
