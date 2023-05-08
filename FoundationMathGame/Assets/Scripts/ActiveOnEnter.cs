using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnEnter : MonoBehaviour
{
    public GameObject dialogue;

    void OnTriggerEnter(Collider other)
    {
        if (dialogue.activeInHierarchy == false)
        {
            dialogue.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        dialogue.SetActive(false);
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
