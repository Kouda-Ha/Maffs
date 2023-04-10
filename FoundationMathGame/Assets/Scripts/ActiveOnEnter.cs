using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnClick : MonoBehaviour
{
    public GameObject dialogue;

    public void OnTriggerEnter(Collider other)
    {
        if (dialogue.activeInHierarchy == false)
        {
            dialogue.SetActive(true);
        }
        else
        {
            dialogue.SetActive(false);
        }
    }
    public void OpenDialogue()
    {
        {
            if (dialogue.activeInHierarchy == false)
            {
                dialogue.SetActive(true);
            }
            else
            {
                dialogue.SetActive(false);
            }
        }
    }
}
