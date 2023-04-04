using EZDoor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject keyObject;
    public Doors doorInteract;
    // Start is called before the first frame update
    void Start()
    {
        keyObject.SetActive(true);
        Doors doorInteract = GetComponent<Doors>();

    }
    
    void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E))
        {
            keyObject.SetActive(false);
            doorInteract.isLocked = false;
        }
        
    }
}