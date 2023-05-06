using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public Transform spawnTransform;
    public GameObject spawnObject;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(spawnObject, spawnTransform.position, spawnTransform.rotation);
        
    }

}
