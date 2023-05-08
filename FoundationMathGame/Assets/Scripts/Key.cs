using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Key script. So doors can be lockable and unlockable, forcing the player to
// do certain sections first in the game, before finding a key/unlocking next doors.
public class Key : MonoBehaviour
{
    public GameObject keyObject;
    public Doors doorInteract;

    void Start()
    {
        keyObject.SetActive(true);
        Doors doorInteract = GetComponent<Doors>();

    }
    
    void OnTriggerStay()
    {
        // Press 'E' to use a key on a locked door, to unlock the door.
        if (Input.GetKey(KeyCode.E))
        {
            keyObject.SetActive(false);
            doorInteract.isLocked = false;
        }
        
    }

}
