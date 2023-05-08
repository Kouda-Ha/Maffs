using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This activates dialogue during things such as the tutorial scene, where there are dialogue boxes 
// subtitling the game tutorial voice over
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
