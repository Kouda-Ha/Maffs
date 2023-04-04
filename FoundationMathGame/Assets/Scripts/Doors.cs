using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Animator animator;
    public bool isLocked = false;
    public bool isOpened = false;

    void start()
    {
        animator = GetComponent<Animator>();

    }

    void OnTriggerStay()
    {
        StartCoroutine("DoorState");    
    }

    IEnumerator DoorState()
    {
        if (isLocked == false)
        {
            if (isOpened == false)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    animator.SetInteger("State", 1);
                    yield return new WaitForSeconds(0.1f);
                    isOpened = true;
                }
            }
            if (isOpened == true)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    animator.SetInteger("State", 2);
                    yield return new WaitForSeconds(0.1f);
                    isOpened = false;
                    animator.SetInteger("State", 0);
                }
            }
        }
    }

}
