using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Door script. Doors are either open or closed, and locked or unlocked. 
public class Doors : MonoBehaviour
{
    public Animator animator;
    // Automatically have doors unlocked and closed, lockable in the Unity inspector
    public bool isLocked = false;
    public bool isOpened = false;

    private Key keyInteract;

    void start()
    {
        animator = GetComponent<Animator>();
        keyInteract = GetComponent<Key>();
    }

    void OnTriggerStay()
    {
        StartCoroutine("DoorState");    
    }

    IEnumerator DoorState()
    {
        // If the door is not locked and isn't open, open it/play open animation on 'E' input
        if (isLocked == false)
        {
            if (isOpened == false)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    animator.SetInteger("State", 1);
                    yield return new WaitForSeconds(0.25f);
                    isOpened = true;
                }
            }
            // If the door is not locked and is open, close it/play close animation on 'E' input
            if (isOpened == true)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    animator.SetInteger("State", 2);
                    yield return new WaitForSeconds(0.25f);
                    isOpened = false;
                    animator.SetInteger("State", 0);
                }
            }
        }
    }
}
